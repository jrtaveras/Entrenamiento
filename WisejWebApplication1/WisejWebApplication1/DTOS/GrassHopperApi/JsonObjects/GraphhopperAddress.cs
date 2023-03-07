using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperAddress
    {
        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        public GraphhopperAddress(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }

}