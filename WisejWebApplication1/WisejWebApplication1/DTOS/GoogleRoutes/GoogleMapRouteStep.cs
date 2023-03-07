using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRouteStep
    {
        [JsonProperty("distanceMeters")]
        public long DistanceMeters { get; set; }

        [JsonProperty("staticDuration")]
        public string StaticDuration { get; set; }

        [JsonProperty("polyline")]
        public GoogleMapRoutePolyline Polyline { get; set; }

        [JsonProperty("startLocation")]
        public GoogleMapRouteLocationCoords StartLocation { get; set; }

        [JsonProperty("endLocation")]
        public GoogleMapRouteLocationCoords EndLocation { get; set; }

        [JsonProperty("navigationInstruction", NullValueHandling = NullValueHandling.Ignore)]
        public GoogleMapRouteNavigationInstruction NavigationInstruction { get; set; }
    }


}