using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.BuildingAggregator
{
    public class Building:BaseEntity,IAggregateRoot
    {
        [JsonPropertyName("shortCut")]
        public string ShortCut { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
}
