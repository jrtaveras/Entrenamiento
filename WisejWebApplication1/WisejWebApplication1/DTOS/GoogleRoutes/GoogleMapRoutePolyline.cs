using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRoutePolyline
    {
        [JsonProperty("encodedPolyline")]
        public string EncodedPolyline { get; set; }
    }


}