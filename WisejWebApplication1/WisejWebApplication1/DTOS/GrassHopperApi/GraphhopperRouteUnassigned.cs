using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi
{
    public partial class GraphhopperRouteUnassigned
    {
        [JsonProperty("services")]
        public object[] Services { get; set; }

        [JsonProperty("shipments")]
        public object[] Shipments { get; set; }

        [JsonProperty("breaks")]
        public object[] Breaks { get; set; }

        [JsonProperty("details")]
        public object[] Details { get; set; }
    }

}