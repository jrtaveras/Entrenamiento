using Newtonsoft.Json;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.DTOS
{
    public partial class GoogleMapDirectionNortheast
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

    }

}