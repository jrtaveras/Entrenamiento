using Newtonsoft.Json;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionStep
    {
        [JsonProperty("distance")]
        public GoogleMapDirectionDistance Distance { get; set; }

        [JsonProperty("duration")]
        public GoogleMapDirectionDistance Duration { get; set; }

        [JsonProperty("end_location")]
        public GoogleMapDirectionNortheast EndLocation { get; set; }

        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty("polyline")]
        public GoogleMapDirectionPolyline Polyline { get; set; }

        [JsonProperty("start_location")]
        public GoogleMapDirectionNortheast StartLocation { get; set; }

        [JsonProperty("travel_mode")]
        public TravelMode TravelMode { get; set; }

        [JsonProperty("maneuver", NullValueHandling = NullValueHandling.Ignore)]
        public string Maneuver { get; set; }
    }

}