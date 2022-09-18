using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async  Task<List<Group>> GetAllGroups()
        {
            return await _groupRepository.GetAll();  
        }

        public async Task<List<Medium>> GetAllMedia()
        {
            return await _groupRepository.GetAllMedia();
        }
    }
}
