using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi
{
    public partial class GraphhopperRouteResponse
    {
        [JsonProperty("copyrights")]
        public string[] Copyrights { get; set; }

        [JsonProperty("job_id")]
        public string JobId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("waiting_time_in_queue")]
        public long WaitingTimeInQueue { get; set; }

        [JsonProperty("processing_time")]
        public long ProcessingTime { get; set; }

        [JsonProperty("solution")]
        public GraphhopperRouteSolution Solution { get; set; }
    }

}