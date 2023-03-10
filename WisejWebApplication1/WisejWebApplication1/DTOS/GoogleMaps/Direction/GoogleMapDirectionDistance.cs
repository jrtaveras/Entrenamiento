using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapDirectionDistance
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

}