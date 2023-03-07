using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRouteResponse
    {
        [JsonProperty("routes")]
        public GoogleMapRoute[] Routes { get; set; }
    }

}