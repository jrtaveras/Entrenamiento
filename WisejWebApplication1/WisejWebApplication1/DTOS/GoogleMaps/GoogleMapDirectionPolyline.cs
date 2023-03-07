using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionPolyline
    {
        [JsonProperty("points")]
        public string Points { get; set; }
    }

}