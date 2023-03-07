using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionLeg
    {
        [JsonProperty("distance")]
        public GoogleMapDirectionDistance Distance { get; set; }

        [JsonProperty("duration")]
        public GoogleMapDirectionDistance Duration { get; set; }

        [JsonProperty("end_address")]
        public string EndAddress { get; set; }

        [JsonProperty("end_location")]
        public GoogleMapDirectionNortheast EndLocation { get; set; }

        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        [JsonProperty("start_location")]
        public GoogleMapDirectionNortheast StartLocation { get; set; }

        [JsonProperty("steps")]
        public GoogleMapDirectionStep[] Steps { get; set; }

        [JsonProperty("traffic_speed_entry")]
        public object[] TrafficSpeedEntry { get; set; }

        [JsonProperty("via_waypoint")]
        public object[] ViaWaypoint { get; set; }
    }

}