using ApplicationCore.Entities.BuildingAggregator;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Model;
using Web.Application.Queries;

namespace Web.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class SearchController : ControllerBase
    {
        private ISearchQuery _searchQuery;
        public SearchController(ISearchQuery searchQuery)
        {
            _searchQuery = searchQuery;
        }

        
        public async Task<List<SearchResult>> Search(string? q)
        {
            return await _searchQuery.Search(q);
        }
    }
}
