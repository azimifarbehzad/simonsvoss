using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Entities.GroupAggregator;

namespace Web.Application.Model
{
    public class SearchResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public ResultType Type { get; set; }
        public string TypeName { get; set; }
        public Lock Lock { get; set; }
        public Building Building { get; set; }
        public Group Group{ get; set; }
        public Medium Medium { get; set; }



    }
    public enum ResultType
    {
        Building,
        Lock,
        Group,
        Medium
    }
}
