using ApplicationCore.Entities.BuildingAggregator;

namespace ApplicationCore.Interfaces
{
    public interface IBuildingRepository
    {
        Building Get(int id);
        Task<List<Building>> GetAll();
        Task<List<Lock>> GetAllLocks();

    }
}