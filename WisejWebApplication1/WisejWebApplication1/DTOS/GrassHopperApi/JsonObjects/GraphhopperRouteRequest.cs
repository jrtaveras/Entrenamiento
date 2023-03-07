using Newtonsoft.Json;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperRouteRequest
    {
        [JsonProperty("vehicles")]
        public GraphhopperVehicle[] Vehicles { get; set; } = { };

        /*[JsonProperty("vehicle_types")]
        public GrassHooperVehicleType[] VehicleTypes { get; set; } = { };*/

        [JsonProperty("services")]
        public GraphhopperService[] Services { get; set; } = { };

        [JsonProperty("shipments")]
        public GraphhopperShipment[] Shipments { get; set; } = { };

        [JsonProperty("objectives")]
        public GraphhopperObjective[] Objectives { get; set; } = { };

        [JsonProperty("configuration")]
        public GraphhopperConfiguration Configuration { get; set; }
    }

}