using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi
{
    public partial class GraphhopperRouteSolution
    {
        [JsonProperty("costs")]
        public long Costs { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("transport_time")]
        public long TransportTime { get; set; }

        [JsonProperty("completion_time")]
        public long CompletionTime { get; set; }

        [JsonProperty("max_operation_time")]
        public long MaxOperationTime { get; set; }

        [JsonProperty("waiting_time")]
        public long WaitingTime { get; set; }

        [JsonProperty("service_duration")]
        public long ServiceDuration { get; set; }

        [JsonProperty("preparation_time")]
        public long PreparationTime { get; set; }

        [JsonProperty("no_vehicles")]
        public long NoVehicles { get; set; }

        [JsonProperty("no_unassigned")]
        public long NoUnassigned { get; set; }

        [JsonProperty("routes")]
        public GraphhopperRoute[] Routes { get; set; }

        [JsonProperty("unassigned")]
        public GraphhopperRouteUnassigned Unassigned { get; set; }
    }

}