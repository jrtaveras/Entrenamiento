using Newtonsoft.Json;
using System;

namespace WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects
{
    public partial class GraphhopperShipment
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("pickup")]
        public GraphhopperDelivery Pickup { get; set; }

        [JsonProperty("delivery")]
        public GraphhopperDelivery Delivery { get; set; }

        [JsonProperty("size")]
        public long[] Size { get; set; }

        [JsonProperty("required_skills")]
        public string[] RequiredSkills { get; set; }
    }

}