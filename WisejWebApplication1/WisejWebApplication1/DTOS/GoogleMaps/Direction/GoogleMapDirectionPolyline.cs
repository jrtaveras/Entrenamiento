using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapDirectionPolyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }
    }

}