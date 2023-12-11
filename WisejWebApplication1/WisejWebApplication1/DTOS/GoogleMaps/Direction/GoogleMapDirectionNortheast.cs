using Newtonsoft.Json;
using Wisej.Web.Ext.GoogleMaps;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapDirectionNortheast
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

    }

}