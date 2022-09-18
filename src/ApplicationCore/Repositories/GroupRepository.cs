
using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class GroupRepository : IRepository<Group>, IGroupRepository
    {
        public Group Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> GetAll()
        {
            string fileName = "wwwroot/sv_lsm_data.json";
            string jsonString = File.ReadAllText(fileName);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            DataFile data =await JsonSerializer.DeserializeAsync<DataFile>(stream)!;
            return data.Groups;
        }

        public async Task<List<Medium>> GetAllMedia()
        {
            string fileName = "wwwroot/sv_lsm_data.json";
            string jsonString = File.ReadAllText(fileName);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            DataFile data =await JsonSerializer.DeserializeAsync<DataFile>(stream)!;
            return data.Mediums;
        }
    }

}
