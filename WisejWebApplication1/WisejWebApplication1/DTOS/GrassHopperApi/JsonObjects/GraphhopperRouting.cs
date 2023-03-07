using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperRouting
    {
        [JsonProperty("calc_points")]
        public bool CalcPoints { get; set; }

        [JsonProperty("snap_preventions")]
        public string[] SnapPreventions { get; set; }
    }

}