using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects
{
    public class GoogleMapRouteLatLng
    {
        public GoogleMapRouteLatLng(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}