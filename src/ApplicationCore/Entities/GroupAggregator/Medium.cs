using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.GroupAggregator
{
    public class Medium:BaseEntity
    {
        [JsonPropertyName("groupId")]
        public Guid GroupId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get;  set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

       

       
    }
    public enum MediumType
    {
        Transponder,
        TransponderWithCardInlay
    }
}
