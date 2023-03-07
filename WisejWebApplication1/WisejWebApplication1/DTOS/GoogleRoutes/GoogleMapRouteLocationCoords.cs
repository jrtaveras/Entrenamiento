using Newtonsoft.Json;
using WisejWebApplication1.DTOS.GoogleRoutes.JsonObjects;

namespace WisejWebApplication1.DTOS.GoogleRoutes
{
    public partial class GoogleMapRouteLocationCoords
    {
        [JsonProperty("latLng")]
        public GoogleMapRouteLatLng LatLng { get; set; }
    }


}