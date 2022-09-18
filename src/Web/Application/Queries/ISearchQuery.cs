using ApplicationCore.Entities.BuildingAggregator;
using Web.Application.Model;

namespace Web.Application.Queries
{
    public interface ISearchQuery
    {

        public  Task<List<SearchResult>> Search(string query);


    }
}
