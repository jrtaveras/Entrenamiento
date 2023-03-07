using Newtonsoft.Json;
using System;
using WisejWebApplication1.DTOS.GrassHopperApi.JsonObjects;

namespace WisejWebApplication1.DTOS.GrassHopperApi
{
    public partial class GraphhopperRouteActivity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("address")]
        public GraphhopperAddress Address { get; set; }

        [JsonProperty("arr_time")]
        public long ArrTime { get; set; }

        [JsonProperty("arr_date_time")]
        public DateTimeOffset ArrDateTime { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("end_date_time")]
        public DateTimeOffset EndDateTime { get; set; }

        [JsonProperty("waiting_time")]
        public long WaitingTime { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("driving_time")]
        public long DrivingTime { get; set; }

        [JsonProperty("preparation_time")]
        public long PreparationTime { get; set; }

        [JsonProperty("load_after", NullValueHandling = NullValueHandling.Ignore)]
        public long[] LoadAfter { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("load_before", NullValueHandling = NullValueHandling.Ignore)]
        public long[] LoadBefore { get; set; }
    }

}