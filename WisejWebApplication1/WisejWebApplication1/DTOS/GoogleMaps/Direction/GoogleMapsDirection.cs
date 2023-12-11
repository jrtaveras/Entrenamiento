using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapsDirection
    {
        [JsonProperty("geocoded_waypoints")]
        public GoogleMapDirectionGeocodedWaypoint[] GeocodedWaypoints { get; set; }

        [JsonProperty("routes")]
        public GoogleMapDirectionRoute[] Routes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

}