using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GoogleMaps.Direction
{
    public partial class GoogleMapDirectionGeocodedWaypoint
    {
        [JsonProperty("geocoder_status")]
        public string GeocoderStatus { get; set; }

        [JsonProperty("partial_match")]
        public bool PartialMatch { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

}