using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperTimeWindow
    {
        [JsonProperty("earliest")]
        public long Earliest { get; set; }

        [JsonProperty("latest")]
        public long Latest { get; set; }
    }

}