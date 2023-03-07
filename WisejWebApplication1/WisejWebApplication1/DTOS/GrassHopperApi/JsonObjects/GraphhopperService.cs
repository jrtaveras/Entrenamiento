using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperService
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public GraphhopperAddress Address { get; set; }

        [JsonProperty("size")]
        public long[] Size { get; set; }

        [JsonProperty("time_windows", NullValueHandling = NullValueHandling.Ignore)]
        public GraphhopperTimeWindow[] TimeWindows { get; set; }
    }

}