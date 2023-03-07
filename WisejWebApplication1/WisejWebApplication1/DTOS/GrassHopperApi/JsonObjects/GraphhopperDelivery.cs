using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperDelivery
    {
        [JsonProperty("address")]
        public GraphhopperAddress Address { get; set; }
    }

}