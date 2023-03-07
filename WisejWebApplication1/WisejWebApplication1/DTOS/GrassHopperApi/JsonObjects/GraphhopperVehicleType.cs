using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperVehicleType
    {
        [JsonProperty("type_id")]
        public string TypeId { get; set; }

        [JsonProperty("capacity")]
        public long[] Capacity { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }

}