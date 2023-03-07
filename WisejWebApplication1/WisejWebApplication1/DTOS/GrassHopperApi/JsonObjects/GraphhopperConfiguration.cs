using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperConfiguration
    {
        [JsonProperty("routing")]
        public GraphhopperRouting Routing { get; set; }
    }

}