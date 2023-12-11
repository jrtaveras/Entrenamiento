using Newtonsoft.Json;
using System.Collections.Generic;

namespace WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects
{
    public class GoogleMapRouteRequest
    {
        [JsonProperty("origin")]
        public GoogleMapRouteLocation Origin { get; set; }

        [JsonProperty("destination")]
        public GoogleMapRouteLocation Destination { get; set; }

        [JsonProperty("intermediates")]
        public List<GoogleMapRouteLocation> Intermediates { get; set; }

        [JsonProperty("optimizeWaypointOrder")]
        public bool OptimizeWaypointOrder { get; set; }
        
        [JsonProperty("travelMode")]
        public string TravelMode { get; set; }

    }
}