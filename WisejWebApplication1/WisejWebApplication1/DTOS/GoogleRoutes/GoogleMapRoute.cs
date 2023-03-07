using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRoute
    {
        [JsonProperty("legs")]
        public GoogleMapRouteLeg[] Legs { get; set; }

        [JsonProperty("distanceMeters")]
        public long DistanceMeters { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("staticDuration")]
        public string StaticDuration { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("warnings")]
        public string[] Warnings { get; set; }

        [JsonProperty("routeLabels")]
        public string[] RouteLabels { get; set; }
    }


}