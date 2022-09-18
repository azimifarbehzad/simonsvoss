using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class BuildingRepository : IRepository<Building>, IBuildingRepository
    {
        public Building Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Building>> GetAll()
        {
            string fileName = "wwwroot/sv_lsm_data.json";
            string jsonString = File.ReadAllText(fileName);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            DataFile data = await JsonSerializer.DeserializeAsync<DataFile>(stream)!;
            return data.Buildings;
        }

        public async Task<List<Lock>> GetAllLocks()
        {
            string fileName = "wwwroot/sv_lsm_data.json";
            string jsonString = File.ReadAllText(fileName);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            DataFile data = await JsonSerializer.DeserializeAsync<DataFile>(stream)!;
            return data.Locks;
        }
    }

}
