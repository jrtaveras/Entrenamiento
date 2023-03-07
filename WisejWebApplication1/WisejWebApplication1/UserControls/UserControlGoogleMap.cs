using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Wisej.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS.GoogleRoutes;
using WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects;
using WisejWebApplication1.DTOS.GrassHopperApi;
using WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects;
using WisejWebApplication1.Helpers.CoordsHelper;
using WisejWebApplication1.Helpers.MapsHelpers;

namespace WisejWebApplication1.UserControls
{
    public partial class UserControlGoogleMap : UserControl
    {
       
        private readonly string _apiKeyGoogleMap = "API_GOOGLEMAPS_AQUI";
        private readonly RestClient _restClient;

        public UserControlGoogleMap()
        {
            InitializeComponent();
            
            _restClient = new RestClient();

            googleMap.ApiKey = _apiKeyGoogleMap;
            googleMap.Appear += GoogleMap_Appear;
        }


        private void CalculateRouteUsingGoogleDirectionAPI()
        {
            string _baseUrl = "https://maps.googleapis.com/maps/api/directions/json";
            DirectionRequest<string, string, LatLng> directionRequest = DirectionRequest.CreateDirection
            (
                origin: CoordsFactory.Origin.ToGoogleMapString(),
                destination: CoordsFactory.Origin.ToGoogleMapString(),
                wayPoints: CoordsFactory.Coords,
                optimizeRoutes: true
            );

            googleMap.CalculateOptimizeRoute(_baseUrl, _restClient, directionRequest, limit: 10);
        }

        private void CalculateRouteUsingGraphHopperAPI(string apiKeyGraphHopper)
        {
            string baseUrl = $"https://graphhopper.com/api/1/vrp?key={apiKeyGraphHopper}";

            GraphhopperRouteRequest routeRequest = new GraphhopperRouteRequest()
            {
                Vehicles = new GraphhopperVehicle[]
                {
                    new GraphhopperVehicle()
                    {
                        VehicleId = "Schad vehicle",
                        StartAddress = CoordsFactory.Origin.ToGrassHooperAddress(),
                        MaxJobs = CoordsFactory.Coords.Length,
                        ReturnToDepot = false
                    },
                },
                Services = CoordsFactory.GetGrassHopperServices()
            };

            RestRequest request = new RestRequest(baseUrl);
            request.AddBody(JsonConvert.SerializeObject(routeRequest));

            RestResponse response = _restClient.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                int index = 0;
                GraphhopperRouteResponse routesResponse = JsonConvert.DeserializeObject<GraphhopperRouteResponse>(response.Content);

                foreach (GraphhopperRoute route in routesResponse.Solution.Routes)
                {
                    LatLng lastCoordDraw = null;
                    foreach (GraphhopperRouteActivity activity in route.Activities)
                    {
                        LatLng coord = activity.Address.ToLatLng();
                        googleMap.AddMarker(MapMarker.Create(Guid.NewGuid().ToString(), coord, $"{index}"));

                        if (lastCoordDraw != null)
                        {
                            googleMap.DrawPolyLine(new MapPolyline()
                            {
                                Path = new LatLng[2] { lastCoordDraw, coord },
                                Geodesic = true,
                                StrokeColor = "#FF0000",
                                StrokeOpacity = 0.8,
                                StrokeWeight = 2,
                            });
                        }

                        if (index == 0)
                        {
                            googleMap.CenterMap(coord);
                        }

                        index++;
                        lastCoordDraw = coord;
                    }

                }

            }

        }

        private void CalculateRouteUsingGoogleRouteAPI(string apiKeyGoogleMapsRoute)
        {
            string baseUrl = $"https://routes.googleapis.com/directions/v2:computeRoutes?key={apiKeyGoogleMapsRoute}";
            var jsonParams = new GoogleMapRouteRequest()
            {
                Origin = CoordsFactory.Origin.ToMapLocation(),
                Destination = CoordsFactory.Origin.ToMapLocation(),
                Intermediates = CoordsFactory.GetMapLocations(),
                TravelMode = "DRIVE",
                OptimizeWaypointOrder = true
            };

            RestRequest request = new RestRequest(baseUrl);
            request.AddHeader("X-Goog-FieldMask", "*");
            request.AddBody(JsonConvert.SerializeObject(jsonParams));
            
            RestResponse response = _restClient.Post(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                int index = 0;
                GoogleMapRouteResponse routesResponse = JsonConvert.DeserializeObject<GoogleMapRouteResponse>(response.Content);

                foreach(GoogleMapRoute route in routesResponse.Routes)
                {
                    foreach (GoogleMapRouteLeg leg in route.Legs)
                    {
                        //LatLngExtentions.ToLatLng()
                        LatLng start = leg.StartLocation.ToLatLng();
                        LatLng end =  leg.EndLocation.ToLatLng();

                        googleMap.AddMarker(MapMarker.Create(Guid.NewGuid().ToString(), start, $"{index}"));

                        //Do not draw last point because we dont care about destination, only waypoints
                        if (index < route.Legs.Length - 1)
                        {
                            googleMap.AddMarker(MapMarker.Create(Guid.NewGuid().ToString(), end, ""));

                            // The JSON configuration of the polygon
                            googleMap.DrawPolyLine(new MapPolyline()
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
                            googleMap.CenterMap(start);
                        }
                        index++;
                    }
                }
            }
        }


        private void GoogleMap_Appear(object sender, EventArgs e)
        {
            //CalculateRouteUsingGoogleDirectionAPI();
            CalculateRouteUsingGraphHopperAPI("API_GRAPHHOPPER AQUI");
        }
    }

}
