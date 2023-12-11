using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects
{

    public class GoogleMapRouteMapCoors
    {
        [JsonProperty("latLng")]
        public GoogleMapRouteLatLng LatLng { get; set; }
        public GoogleMapRouteMapCoors(double latitude, double longitude)
        {
            LatLng = new GoogleMapRouteLatLng(latitude, longitude);
        }
    }
}