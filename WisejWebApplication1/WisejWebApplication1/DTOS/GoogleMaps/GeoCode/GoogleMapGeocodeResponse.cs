using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisejWebApplication1.DTOS.GoogleMaps.GeoCode
{
    public partial class GoogleMapsGeoCodeResponse
    {
        [JsonProperty("results")]
        public GoogleMapsGeoCodeResult[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class GoogleMapsGeoCodeResult
    {
        [JsonProperty("address_components")]
        public GoogleMapsGeoCodeAddressComponent[] AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public GoogleMapsGeoCodeGeometry Geometry { get; set; }

        [JsonProperty("partial_match")]
        public bool PartialMatch { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("plus_code")]
        public GoogleMapsGeoCodePlusCode PlusCode { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public partial class GoogleMapsGeoCodeAddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public partial class GoogleMapsGeoCodeGeometry
    {
        [JsonProperty("location")]
        public GoogleMapsGeoCodeLocation Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("viewport")]
        public GoogleMapsGeoCodeViewport Viewport { get; set; }
    }

    public partial class GoogleMapsGeoCodeLocation
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public partial class GoogleMapsGeoCodeViewport
    {
        [JsonProperty("northeast")]
        public GoogleMapsGeoCodeLocation Northeast { get; set; }

        [JsonProperty("southwest")]
        public GoogleMapsGeoCodeLocation Southwest { get; set; }
    }

    public partial class GoogleMapsGeoCodePlusCode
    {
        [JsonProperty("compound_code")]
        public string CompoundCode { get; set; }

        [JsonProperty("global_code")]
        public string GlobalCode { get; set; }
    }
}
