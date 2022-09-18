using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<List<Building>> GetAllBuldings()
        {
            return await _buildingRepository.GetAll();
        }

        public async Task<List<Lock>> GetAllLocks()
        {
            return await _buildingRepository.GetAllLocks();
        }
    }
}
