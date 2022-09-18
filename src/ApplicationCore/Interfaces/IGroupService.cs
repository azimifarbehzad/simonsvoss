using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGroupService
    {
        public Task<List<Group>> GetAllGroups();
        public Task<List<Medium>> GetAllMedia();

    }
}
