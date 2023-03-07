using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionDistance
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

}