using Moq;
using Web.Application.Model;
using Web.Application.Queries;
using Web.Controllers;

namespace UnitTests
{
    public class SearchControllerTest
    {
        [Fact]
        public async Task Search_ReturnsItems_WithAListOfSearchResult()
        {
            // Arrange
            var mockRepo = new Mock<ISearchQuery>();
            mockRepo.Setup(repo => repo.Search("q"))
                .ReturnsAsync(GetTestResults());
            var controller = new SearchController(mockRepo.Object);

            // Act
            var result = await controller.Search("q");

            // Assert
            
            Assert.Equal(2, result.Count);
        }
        private List<SearchResult> GetTestResults()
        {
            var items = new List<SearchResult>();
            items.Add(new SearchResult()
            {
                TypeName = "Building",
                Id = Guid.NewGuid(),
                Name = "Test One",
                Score=1,
                Description="de",
                Type=ResultType.Building
            });
            items.Add(new SearchResult()
            {
                TypeName = "Lock",
                Id = Guid.NewGuid(),
                Name = "Test Two",
                Score = 2,
                Description = "de",
                Type=ResultType.Lock

            });
            return items;
        }
    }
}