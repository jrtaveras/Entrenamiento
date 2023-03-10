using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Wisej.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS.GoogleMaps.Direction;
using WisejWebApplication1.DTOS.GoogleMaps.GeoCode;
using WisejWebApplication1.DTOS.GoogleRoutes;
using WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects;
using WisejWebApplication1.DTOS.GrassHopperApi;
using WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects;
using WisejWebApplication1.Helpers.MapsHelpers;

namespace WisejWebApplication1.UserControls
{
    public partial class UserControlGoogleMap : UserControl
    {
        private GoogleMap _googleMap;
        private readonly RestClient _restClient;
        private List<LatLng> _points;

        private enum MapServices
        {
            GoogleMapsDirection,
            GoogleMapsRoutes,
            GraphHooper,
        }

        private enum LocationTypes
        {
            Direccion,
            Coordenadas,
            PlaceID,
        }

        public UserControlGoogleMap()
        {
            InitializeComponent();
            
            _restClient = new RestClient();

            ComboBoxMapServices.DataSource = Enum.GetNames(typeof(MapServices));
            ComboBoxLocationTypes.DataSource = Enum.GetNames(typeof(LocationTypes));

            PanelMapServices.Enabled = false;
            
            _points = new List<LatLng>();
        }

        private void CalculateRouteUsingGoogleDirectionAPI(string apiKeyGoogleMapsDirection, LatLng origin, LatLng destination, LatLng [] wayPoints)
        {
            try
            {
                //if google map already has a key then use the key
                _googleMap.ApiKey = _googleMap.ApiKey ?? apiKeyGoogleMapsDirection;

                string _baseUrl = "https://maps.googleapis.com/maps/api/directions/json";
                GoogleMapsDirectionRequest directionRequest = new GoogleMapsDirectionRequest
                (
                    origin: origin,
                    destination: destination,
                    wayPoints: wayPoints,
                    optimizeRoutes: true
                );

                string url = _googleMap.CreateDirectionUrl(_baseUrl, directionRequest);
                RestResponse result = _restClient.Get(new RestRequest(url));

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
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
                        _googleMap.AddMarker(new MapMarker(startMarkerId, start, $"{index}"));

                        //Do not draw last point because we dont care about destination, only waypoints
                        if (index < route.Legs.Length - 1)
                        {
                            _googleMap.AddMarker(new MapMarker(Guid.NewGuid().ToString(), end, ""));

                            // The JSON configuration of the polygon
                            _googleMap.DrawPolyLine(new MapPolyline()
                            {
                                Path = new LatLng[] { start, end },
                                Geodesic = true,
                                StrokeColor = "#FF0000",
                                StrokeOpacity = 0.8,
                                StrokeWeight = 2,
                            });
                        }
                        index++;
                    }

                    _googleMap.CenterMap(route.Legs.First().StartLocation.ToLatLng());
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private void CalculateRouteUsingGraphHopperAPI(string apiKeyGraphHopper, LatLng origin, LatLng[] wayPoints)
        {
            string baseUrl = $"https://graphhopper.com/api/1/vrp?key={apiKeyGraphHopper}";

            GraphhopperRouteRequest routeRequest = new GraphhopperRouteRequest()
            {
                Vehicles = new GraphhopperVehicle[]
                {
                    new GraphhopperVehicle()
                    {
                        VehicleId = "Schad vehicle",
                        StartAddress = origin.ToGrassHooperAddress(),
                        MaxJobs = wayPoints.Length,
                        ReturnToDepot = false,
                    },
                },
                Services = wayPoints.Select(g => g.ToGraphhopperService()).ToArray()
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
                        _googleMap.AddMarker(new MapMarker(Guid.NewGuid().ToString(), coord, $"{index}"));

                        if (lastCoordDraw != null)
                        {
                            _googleMap.DrawPolyLine(new MapPolyline()
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
                            _googleMap.CenterMap(coord);
                        }

                        index++;
                        lastCoordDraw = coord;
                    }

                }

            }

        }
        private void CalculateRouteUsingGoogleRouteAPI(string apiKeyGoogleMapsRoute, LatLng origin, LatLng destination, LatLng[] wayPoints)
        {
            string baseUrl = $"https://routes.googleapis.com/directions/v2:computeRoutes?key={apiKeyGoogleMapsRoute}";
            var jsonParams = new GoogleMapRouteRequest()
            {
                Origin = origin.ToMapLocation(),
                Destination = destination.ToMapLocation(),
                Intermediates = wayPoints.Select(w => w.ToMapLocation()).ToList(),
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

                        _googleMap.AddMarker(new MapMarker(Guid.NewGuid().ToString(), start, $"{index}"));

                        //Do not draw last point because we dont care about destination, only waypoints
                        if (index < route.Legs.Length - 1)
                        {
                            _googleMap.AddMarker(new MapMarker(Guid.NewGuid().ToString(), end, ""));

                            // The JSON configuration of the polygon
                            _googleMap.DrawPolyLine(new MapPolyline()
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
                            _googleMap.CenterMap(start);
                        }
                        index++;
                    }
                }
            }
        }

        private LatLng GetCoordsWithStringDirectionUsingGoogleGeoCodeAPI(string apiKeyGoogleMaps, string direction, bool isPlaceId = false)
        {
            try
            {
                //if google map already has a key then use the key
                _googleMap.ApiKey = _googleMap.ApiKey ?? apiKeyGoogleMaps;

                string _baseUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={direction}&key={apiKeyGoogleMaps}";

                GoogleMapGeocodeRequest requestObj = isPlaceId 
                    ? GoogleMapGeocodeRequest.CreateWithPlaceId(direction) 
                    : GoogleMapGeocodeRequest.CreateWithAddress(direction);

                RestRequest request = new RestRequest(_baseUrl);
                request.AddBody(requestObj.ToJSON());

                RestResponse result = _restClient.Post(request);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string content = result.Content;
                    GoogleMapsGeoCodeResponse dTOGoogleMaps = JsonConvert.DeserializeObject<GoogleMapsGeoCodeResponse>(content);

                    GoogleMapsGeoCodeResult geoCodeResult = dTOGoogleMaps.Results.FirstOrDefault();

                    return geoCodeResult?.Geometry?.Location?.ToLatLng();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        private void GoogleMap_Appear(object sender, EventArgs e)
        {
            PanelMapServices.Enabled = true;
        }

        private void ButtonLoadMap_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBoxApiKey.Text))
            {
                AlertBox.Show("Debe introducir el Api Key para mostrar el mapa", MessageBoxIcon.Warning);
                PanelMapServices.Enabled = false;
                return;
            }
            else
            {
                //Se debe hacer esta truculencia cuando se desee crear el control de google maps dinamicamente
                if(_googleMap == null)
                {
                    _googleMap = new GoogleMap
                    {
                        ApiKey = TextBoxApiKey.Text,
                        Location = new System.Drawing.Point(24, 204),
                        Size = new System.Drawing.Size(831, 353)
                    };

                    _googleMap.Appear += GoogleMap_Appear;
                    this.Controls.Add(_googleMap);
                }

            }
        }

        private void ButtonOptimizeRoutes_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxApiKeyService.Text))
                {
                    AlertBox.Show("Debe introducir el Api Key a utilizar en el servicio", MessageBoxIcon.Warning);
                    return;
                }

                if(_points.Count < 3)
                {
                    AlertBox.Show("Debe introducir al menos 3 puntos", MessageBoxIcon.Warning);
                    return;
                }

                _googleMap.ClearMarkers();
                _googleMap.ClearPolyLines();

                string apiKeyService = TextBoxApiKeyService.Text;
                Enum.TryParse(ComboBoxMapServices.SelectedValue.ToString(), out MapServices result);
                switch (result)
                {
                    case MapServices.GoogleMapsDirection:
                        CalculateRouteUsingGoogleDirectionAPI(
                            apiKeyService, 
                            origin: _points[0], 
                            destination: _points[0],
                            wayPoints: _points.Skip(1).ToArray()
                        );
                        break;
                    case MapServices.GoogleMapsRoutes:
                        CalculateRouteUsingGoogleRouteAPI(
                            apiKeyService,
                            origin: _points[0],
                            destination: _points[0],
                            wayPoints: _points.Skip(1).ToArray()
                        );
                        break;
                    case MapServices.GraphHooper:
                        CalculateRouteUsingGraphHopperAPI(
                            apiKeyService,
                            origin: _points[0],
                            wayPoints: _points.Skip(1).ToArray()
                        );
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
                AlertBox.Show("Ha ocurrido un error al calcular las rutas, verifique que el api key del servicio esté correcto", MessageBoxIcon.Warning);
            }
            
        }

        private void ButtonAddLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBoxLocation.Text))
                {
                    AlertBox.Show("Debe introducir una localización", MessageBoxIcon.Warning);
                    return;
                }

                string location = TextBoxLocation.Text;
                Enum.TryParse(ComboBoxLocationTypes.SelectedValue.ToString(), out LocationTypes result);
                switch (result)
                {
                    case LocationTypes.Direccion:
                        LatLng directionCoords = GetCoordsWithStringDirectionUsingGoogleGeoCodeAPI(_googleMap.ApiKey, location);
                        if(directionCoords != null)
                        {
                            _googleMap.AddMarker(new MapMarker(Guid.NewGuid(), location));
                            _googleMap.CenterMap(location);
                            _points.Add(directionCoords);
                        }
                        else
                        {
                            AlertBox.Show("No se ha podido encontrar la dirección", MessageBoxIcon.Warning);
                        }

                        break;
                    case LocationTypes.Coordenadas:
                        
                        if(LatLngHelpers.TryParse(location, out LatLng latLng))
                        {
                            _googleMap.AddMarker(new MapMarker(Guid.NewGuid(), latLng));
                            _googleMap.CenterMap(location);
                            _points.Add(latLng);
                        }
                        else
                        {
                            AlertBox.Show("Las coordenadas no son válidas", MessageBoxIcon.Warning);
                        }
                        break;
                    case LocationTypes.PlaceID:
                        LatLng placeIdCoords = GetCoordsWithStringDirectionUsingGoogleGeoCodeAPI(_googleMap.ApiKey, location, isPlaceId: true);
                        if (placeIdCoords != null)
                        {
                            _googleMap.AddMarker(new MapMarker(Guid.NewGuid(), location));
                            _googleMap.CenterMap(location);
                            _points.Add(placeIdCoords);
                        }
                        else
                        {
                            AlertBox.Show("No se ha podido encontrar la dirección con el placeId", MessageBoxIcon.Warning);
                        }

                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
                AlertBox.Show("Ha ocurrido un error al calcular las rutas, verifique que el api key del servicio esté correcto", MessageBoxIcon.Warning);
            }
        }

    }

}
