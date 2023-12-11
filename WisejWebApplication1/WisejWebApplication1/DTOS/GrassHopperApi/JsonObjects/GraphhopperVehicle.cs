using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperVehicle
    {
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }

        /*[JsonProperty("type_id")]
        public string TypeId { get; set; }*/

        [JsonProperty("start_address")]
        public GraphhopperAddress StartAddress { get; set; }

        //[JsonProperty("earliest_start")]
        //public long EarliestStart { get; set; }

        //[JsonProperty("latest_end")]
        //public long LatestEnd { get; set; }

        [JsonProperty("max_jobs")]
        public long MaxJobs { get; set; }

        [JsonProperty("skills", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Skills { get; set; }

        [JsonProperty("return_to_depot")]
        public bool ReturnToDepot { get; set; }
    }

}