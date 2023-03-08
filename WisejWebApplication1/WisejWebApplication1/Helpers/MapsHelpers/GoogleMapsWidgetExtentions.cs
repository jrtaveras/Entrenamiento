using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS;

namespace WisejWebApplication1.Helpers.MapsHelpers
{
    public static class GoogleMapsWidgetExtentions
    {
        private const string _polyArr = "polyArr";
        /// <summary>
        /// Calculate the optimize route for google direction api
        /// </summary>
        /// <param name="map">The current <see cref="GoogleMap"/> instance</param>
        /// <param name="baseUrl">The base url to use to make the petition</param>
        /// <param name="restClient">The <see cref="RestClient"/> client to use to look for</param>
        /// <param name="directionRequest">The <see cref="DirectionRequest"/> object to use to create the url params to look for dhe optimize route</param>
        /// <param name="limit">A limit to segment the routes</param>
        /// <remarks>
        /// Each petition will be segment using the <paramref name="limit"/> and taking the last stop as the new origin stop for the new route petition
        /// </remarks>
        public static void CalculateOptimizeRoute(this GoogleMap map, string baseUrl,
            RestClient restClient, DirectionRequest directionRequest, int limit = 10)
        {

            //Create another direction to represent a part of the route
            DirectionRequest directionChunk = new DirectionRequest()
            {
                Origin = directionRequest.Origin,
                Destination = directionRequest.Origin,
                OptimizeRoutes = directionRequest.OptimizeRoutes
            };

            int displayStartIndex = 0;

            List<string> wayPointChunk = new List<string>();
            foreach (string wayPoint in directionRequest.WayPoints)
            {
                if (wayPointChunk.Count == limit)
                {
                    //addind the chunk of waypoint to direction
                    directionChunk.WayPoints = wayPointChunk;

                    bool omitMarker = displayStartIndex > 0;
                    string lastWayPoint = DrawRoutes(map, restClient, baseUrl, directionChunk, displayStartIndex: displayStartIndex, omitStartMarkerForFirstIteration: omitMarker);
                    if (string.IsNullOrWhiteSpace(lastWayPoint))
                    {
                        throw new InvalidOperationException("Cannot find the last waypoint to create the next route");
                    }

                    //Creating a new direction with the last waypoint as origin
                    directionChunk = new DirectionRequest()
                    {
                        Origin = lastWayPoint,
                        Destination = lastWayPoint,
                        OptimizeRoutes = directionRequest.OptimizeRoutes
                    };

                    displayStartIndex += limit;
                    
                    //Clear the list and adding the next element
                    wayPointChunk.Clear();
                    wayPointChunk.Add(wayPoint);
                }
                else
                {
                    wayPointChunk.Add(wayPoint);
                }

            }

            if(wayPointChunk.Count > 0)
            {
                directionChunk.WayPoints = wayPointChunk;
                DrawRoutes(map, restClient, baseUrl, directionChunk, displayStartIndex: displayStartIndex);

                wayPointChunk.Clear();
            }

        }


        /// This method is the one who draw the lines between each point
        public static string DrawRoutes(this GoogleMap map,
            RestClient restClient, string baseUrl, 
            DirectionRequest directionRequest,
            int displayStartIndex, bool omitStartMarkerForFirstIteration = false)
        {
            string url = map.CreateDirectionUrl(baseUrl, directionRequest);
            RestResponse result = restClient.Get(new RestRequest(url));

            string lastCoords = "";
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                int index = 0;
                string content = result.Content;
                GoogleMapsDirection dTOGoogleMaps = JsonConvert.DeserializeObject<GoogleMapsDirection>(content);
                
                GoogleMapDirectionRoute route = dTOGoogleMaps.Routes.First();
                foreach (GoogleMapDirectionLeg leg in route.Legs)
                {
                    LatLng start = leg.StartLocation.ToLatLng();
                    LatLng end = leg.EndLocation.ToLatLng();


                    string startMarkerId = Guid.NewGuid().ToString();
                    map.AddMarker(new MapMarker(startMarkerId, start, $"{displayStartIndex}"));
                    if (index == 0 && omitStartMarkerForFirstIteration)
                    {
                        map.RemoveMarker(startMarkerId);
                    }

                    //Do not draw last point because we dont care about destination, only waypoints
                    if (index < route.Legs.Length - 1)
                    {
                        map.AddMarker(new MapMarker(Guid.NewGuid().ToString(), end, ""));

                        // The JSON configuration of the polygon
                        map.DrawPolyLine(new MapPolyline()
                        {
                            Path = new LatLng[] { start, end },
                            Geodesic = true,
                            StrokeColor = "#FF0000",
                            StrokeOpacity = 0.8,
                            StrokeWeight = 2,
                        });
                    }

                    if (index == 0)
                    {
                        map.CenterMap(start);
                    }

                    displayStartIndex++;
                    index++;
                }

                lastCoords = route.Legs.Last().StartLocation.ToGoogleMapString();
            }

            return lastCoords;
        }

        /// <summary>
        /// Generates the string representation of the current <see cref="DirectionRequest"/> 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="baseUrl"></param>
        /// <param name="direction"></param>
        /// <returns>An <see cref="string"/> representation of the current <see cref="DirectionRequest"/></returns>
        public static string CreateDirectionUrl(this GoogleMap map, string baseUrl, DirectionRequest direction)
        {
            string origin = direction.Origin;
            string destination = direction.Destination;
            string wayPoints = direction.GetwayPointsAsString();

            return $"{baseUrl}?origin={origin}&waypoints=optimize:{(direction.OptimizeRoutes ? "true" : "false")}|{wayPoints}&destination={destination}&key={map.ApiKey}";
        }

        /// <summary>
        /// Adds a new marker to the current <paramref name="map"/> instance
        /// </summary>
        /// <param name="map">The current <see cref="GoogleMap"/> instance</param>
        /// <param name="marker">The marker to add to the map</param>
        public static void AddMarker(this GoogleMap map, MapMarker marker)
        {
            map.AddMarker(marker.Id, marker.Position, options: new
            {
                label = marker.Label,
            });
        }

        /// <summary>
        /// Draw a line between the specified coordinates
        /// </summary>
        /// <param name="map">The current <see cref="GoogleMap"/> instance</param>
        /// <param name="polyline">A polyline representation object to draw the line into the map</param>
        public static string DrawPolyLine(this GoogleMap map, MapPolyline polyline)
        {
            var coorsPath = new
            {
                path = polyline.Path.Select(l => new { lat = l.Lat, lng = l.Lng }).ToArray(),
                geodesic = polyline.Geodesic,
                strokeColor = polyline.StrokeColor,
                strokeOpacity = polyline.StrokeOpacity,
                strokeWeight = polyline.StrokeWeight,
            };

            string polyId = Guid.NewGuid().ToString();
            map.Eval($@"

                let exists = this.map.hasOwnProperty('{_polyArr}');                
                if(exists == false){{
                    this.map.{_polyArr} = [];
                }}

                let newPoly = new google.maps.Polyline({coorsPath.ToJSON()});
                newPoly.setMap(this.map);
                
                this.map.{_polyArr}.push({{id: '{polyId}', poly: newPoly}}); 
            ");

            return polyId;
        }

        public static void RemovePolyLine(this GoogleMap map, string polyId)
        {
            map.Eval($@"

                let exists = this.map.hasOwnProperty('{_polyArr}');                
                if(exists == false){{
                    return;
                }}

                let polyObj = this.map.{_polyArr}.find(p => p.id == '{polyId}');
                if(polyObj){{
                    let index = this.map.{_polyArr}.indexOf(polyObj);
                    this.map.{_polyArr}.splice(index, 1);
                    polyObj.poly.setMap(null);
                }}
            ");
        }

        public static void ClearPolyLines(this GoogleMap map)
        {
            map.Eval($@"

                let exists = this.map.hasOwnProperty('{_polyArr}');                
                if(exists == false){{
                    return;
                }}

                for (const polyLine of this.map.{_polyArr}) {{
                    polyLine.poly.setMap(null);
                }}
                
                this.map.{_polyArr} = [];
            ");
        }

    }
}