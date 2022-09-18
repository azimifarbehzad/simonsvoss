using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class DataFile
    {
        public DataFile()
        {
            Buildings = new List<Building>();
            Locks = new List<Lock>();
            Groups = new List<Group>();
            Mediums = new List<Medium>();
        }
        [JsonPropertyName("buildings")]
        public List<Building> Buildings { get; set; }
        [JsonPropertyName("locks")]
        public List<Lock> Locks { get; set; }
        [JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }
        [JsonPropertyName("media")]
        public List<Medium> Mediums { get; set; }

    }
}
