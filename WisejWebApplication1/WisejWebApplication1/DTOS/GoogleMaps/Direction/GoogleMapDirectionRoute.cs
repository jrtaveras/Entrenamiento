using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapDirectionRoute
    {
        [JsonProperty("bounds")]
        public GoogleMapDirectionBounds Bounds { get; set; }

        [JsonProperty("copyrights")]
        public string Copyrights { get; set; }

        [JsonProperty("legs")]
        public GoogleMapDirectionLeg[] Legs { get; set; }

        [JsonProperty("overview_polyline")]
        public GoogleMapDirectionPolyline OverviewPolyline { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("warnings")]
        public object[] Warnings { get; set; }

        [JsonProperty("waypoint_order")]
        public object[] WaypointOrder { get; set; }
    }

}