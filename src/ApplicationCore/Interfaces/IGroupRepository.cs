using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;

namespace ApplicationCore.Interfaces
{
    public interface IGroupRepository
    {
        Group Get(int id);
        Task<List<Group>> GetAll();
        Task<List<Medium>> GetAllMedia();

    }
}