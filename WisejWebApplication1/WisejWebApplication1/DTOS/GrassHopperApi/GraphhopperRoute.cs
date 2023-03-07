using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi
{
    public partial class GraphhopperRoute
    {
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }

        [JsonProperty("shift_id")]
        public string ShiftId { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("transport_time")]
        public long TransportTime { get; set; }

        [JsonProperty("completion_time")]
        public long CompletionTime { get; set; }

        [JsonProperty("waiting_time")]
        public long WaitingTime { get; set; }

        [JsonProperty("service_duration")]
        public long ServiceDuration { get; set; }

        [JsonProperty("preparation_time")]
        public long PreparationTime { get; set; }

        [JsonProperty("activities")]
        public GraphhopperRouteActivity[] Activities { get; set; }
    }

}