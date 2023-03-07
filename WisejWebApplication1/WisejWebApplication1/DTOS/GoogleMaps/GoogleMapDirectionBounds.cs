using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionBounds
    {
        [JsonProperty("northeast")]
        public GoogleMapDirectionNortheast Northeast { get; set; }

        [JsonProperty("southwest")]
        public GoogleMapDirectionNortheast Southwest { get; set; }
    }

}