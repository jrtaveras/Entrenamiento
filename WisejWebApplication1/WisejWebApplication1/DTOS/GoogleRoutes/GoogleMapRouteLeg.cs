using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRouteLeg
    {
        [JsonProperty("distanceMeters")]
        public long DistanceMeters { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("staticDuration")]
        public string StaticDuration { get; set; }

        [JsonProperty("polyline")]
        public GoogleMapRoutePolyline Polyline { get; set; }

        [JsonProperty("startLocation")]
        public GoogleMapRouteLocationCoords StartLocation { get; set; }

        [JsonProperty("endLocation")]
        public GoogleMapRouteLocationCoords EndLocation { get; set; }

        [JsonProperty("steps")]
        public GoogleMapRouteStep[] Steps { get; set; }
    }


}