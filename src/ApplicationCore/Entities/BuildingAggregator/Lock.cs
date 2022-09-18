using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.BuildingAggregator
{
    public class Lock:BaseEntity
    {
        [JsonPropertyName("buildingId")]
        public Guid BuildingId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("floor")]
        public string Floor { get; set; }

        [JsonPropertyName("roomNumber")]
        public string RoomNumber { get; set; }

    }
    public enum LockType
    {
        SmartHandle,
        Cylinder
    }
}
