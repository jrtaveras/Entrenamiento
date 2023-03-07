using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects
{
    public class GoogleMapRouteLocation
    {
        [JsonProperty("location")]
        public GoogleMapRouteMapCoors Location { get; set; }

        public GoogleMapRouteLocation(GoogleMapRouteMapCoors location)
        {
            Location = location;
        }
    }
}