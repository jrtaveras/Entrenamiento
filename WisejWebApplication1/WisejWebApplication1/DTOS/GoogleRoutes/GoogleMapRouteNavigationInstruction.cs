using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRouteNavigationInstruction
    {
        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }

        [JsonProperty("instructions")]
        public string Instructions { get; set; }
    }


}