using ApplicationCore.Entities.BuildingAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingService
    {
        public Task<List<Building>> GetAllBuldings();
        public Task<List<Lock>> GetAllLocks();

    }
}
