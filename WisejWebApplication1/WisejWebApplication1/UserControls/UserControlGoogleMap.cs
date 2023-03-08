using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Wisej.Web;
using Wisej.Web.Ext.GoogleMaps;
using WisejWebApplication1.DTOS;
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
        private GoogleMap _googleMap;
        private readonly RestClient _restClient;

        private enum MapServices
        {
            GoogleMapsDirection,
            GoogleMapsRoutes,
            GraphHooper,
        }

        public UserControlGoogleMap()
        {
            InitializeComponent();
            
            _restClient = new RestClient();

            ComboBoxMapServices.DataSource = Enum.GetNames(typeof(MapServices));
            PanelMapServices.Enabled = false;
        }

        private void CalculateRouteUsingGoogleDirectionAPI(string apiKeyGoogleMapsDirection)
        {
            try
            {
                //if google map already has a key then use the key
                _googleMap.ApiKey = _googleMap.ApiKey ?? apiKeyGoogleMapsDirection;

                string _baseUrl = "https://maps.googleapis.com/maps/api/directions/json";
                DirectionRequest directionRequest = new DirectionRequest
                (
                    origin: CoordsFactory.Origin.ToGoogleMapString(),
                    destination: CoordsFactory.Origin.ToGoogleMapString(),
                    wayPoints: CoordsFactory.Coords.Take(20).ToList(),
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
        private void CalculateRouteUsingGoogleRouteAPI(string apiKeyGoogleMapsRoute)
        {
            string baseUrl = $"https://routes.googleapis.com/directions/v2:computeRoutes?key={apiKeyGoogleMapsRoute}";
            var jsonParams = new GoogleMapRouteRequest()
            {
                Origin = CoordsFactory.Origin.ToMapLocation(),
                Destination = CoordsFactory.Origin.ToMapLocation(),
                Intermediates = CoordsFactory.GetMapLocations().Take(22).ToList(),
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

                _googleMap.ClearMarkers();
                _googleMap.ClearPolyLines();

                string apiKeyService = TextBoxApiKeyService.Text;
                Enum.TryParse(ComboBoxMapServices.SelectedValue.ToString(), out MapServices result);
                switch (result)
                {
                    case MapServices.GoogleMapsDirection:
                        CalculateRouteUsingGoogleDirectionAPI(apiKeyService);
                        break;
                    case MapServices.GoogleMapsRoutes:
                        CalculateRouteUsingGoogleRouteAPI(apiKeyService);
                        break;
                    case MapServices.GraphHooper:
                        CalculateRouteUsingGraphHopperAPI(apiKeyService);
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
