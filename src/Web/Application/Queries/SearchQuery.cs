using ApplicationCore.Constants;
using ApplicationCore.Entities.BuildingAggregator;
using ApplicationCore.Interfaces;
using Web.Application.Model;

namespace Web.Application.Queries
{
    public class SearchQuery : ISearchQuery
    {
        private readonly IBuildingService _buildingService;
        private readonly IGroupService _groupService;

        public SearchQuery(IBuildingService buildingService, IGroupService groupService)
        {
            _buildingService = buildingService;
            _groupService = groupService;
        }


        public async Task<List<SearchResult>> Search(string queryParam)
        {
            if (queryParam == null)
                return new List<SearchResult>();
            queryParam = queryParam.ToLower();
            IEnumerable<SearchResult> query = await SearchBuildings(queryParam);
            IEnumerable<SearchResult> buildingLockQuery = await SearchBuildingLocks(queryParam);
            IEnumerable<SearchResult> lockQuery =await SearchLocks(queryParam);

            IEnumerable<SearchResult> groupQuery = await SearchGroups(queryParam);
            IEnumerable<SearchResult> groupMediaQuery = await SearchGroupMedia(queryParam);
            IEnumerable<SearchResult> mediaQuery = await SearchMedia(queryParam);

            return query
                .Concat(buildingLockQuery)
                .Concat(lockQuery)
                .Concat(groupQuery)
                .Concat(groupMediaQuery)
                .Concat(mediaQuery)
                .OrderByDescending(x => x.Score)
                .GroupBy(x => new { x.Id, x.Type })
                .Select(g => g.First())
                .ToList();
        }

        private async Task<IEnumerable<SearchResult>> SearchLocks(string queryParam)
        {
            return from l in await _buildingService.GetAllLocks()

                   let nameMatch = l.Name.ToLower() == queryParam
                   let nameContain = l.Name.ToLower().Contains(queryParam)

                   let descMatch = (l.Description != null && l.Description.ToLower() == queryParam)
                   let descContain = (l.Description != null && l.Description.ToLower().Contains(queryParam))

                   let typeMatch = (l.Type != null && l.Type.ToLower() == queryParam)
                   let typeContain = (l.Type != null && l.Type.ToLower().Contains(queryParam))
                   let serialNumberMatch = (l.SerialNumber != null && l.SerialNumber.ToLower() == queryParam)
                   let serialNumberContain = (l.SerialNumber != null && l.SerialNumber.ToLower().Contains(queryParam))
                   let floorMatch = (l.Floor != null && l.Floor.ToLower() == queryParam)
                   let floorContain = (l.Floor != null && l.Floor.ToLower().Contains(queryParam))
                   let roomNumberMatch = (l.RoomNumber != null && l.RoomNumber.ToLower() == queryParam)
                   let roomNumberContain = (l.RoomNumber != null && l.RoomNumber.ToLower().Contains(queryParam))

                   let score = (nameMatch ? LockConstant.Name * 10 : nameContain ? LockConstant.Name : 0) + (descMatch ? LockConstant.Description * 10 : descContain ? LockConstant.Description : 0)
                   + (typeMatch ? LockConstant.Type * 10 : typeContain ? LockConstant.Type : 0)
                   + (serialNumberMatch ? LockConstant.SerialNumber * 10 : serialNumberContain ? LockConstant.SerialNumber : 0)
                   + (floorMatch ? LockConstant.Floor * 10 : floorContain ? LockConstant.Floor : 0)
                   + (roomNumberMatch ? LockConstant.RoomNumber * 10 : roomNumberContain ? LockConstant.RoomNumber : 0)

                   where nameMatch || descMatch || nameContain || descContain || typeContain || typeMatch || serialNumberMatch || floorMatch || roomNumberMatch || serialNumberContain || floorContain || roomNumberContain
                   orderby score descending
                   select new SearchResult { Description = l.Description, Score = score, Name = l.Name, TypeName = Enum.GetName(typeof(ResultType), ResultType.Lock), Type = ResultType.Lock, Id = l.Id, Lock = l };
        }

        private async Task<IEnumerable<SearchResult>> SearchBuildingLocks(string queryParam)
        {
            return from b in await _buildingService.GetAllBuldings()
                   join l in await _buildingService.GetAllLocks() on b.Id equals l.BuildingId

                   let nameMatch = b.Name.ToLower() == queryParam
                   let nameContain = b.Name.ToLower().Contains(queryParam)

                   let descMatch = b.Description.ToLower() == queryParam
                   let descContain = b.Description.ToLower().Contains(queryParam)

                   let shortCutMatch = b.ShortCut.ToLower() == queryParam
                   let shortCutContain = b.ShortCut.ToLower().Contains(queryParam)



                   let score = (nameMatch ? LockConstant.BuildingConstant.Name * 10 : nameContain ? LockConstant.BuildingConstant.Name : 0)
                   + (descMatch ? LockConstant.BuildingConstant.Description * 10 : descContain ? LockConstant.BuildingConstant.Description : 0)
                   + (shortCutMatch ? BuildingConstant.ShortCut * 10 : shortCutContain ? BuildingConstant.ShortCut : 0)
                   where nameMatch || descMatch || nameContain || descContain || shortCutContain || shortCutMatch
                   orderby score descending
                   select new SearchResult { Description = l.Description, Score = score, Name = l.Name, TypeName = Enum.GetName(typeof(ResultType), ResultType.Lock), Type = ResultType.Lock, Id = l.Id, Lock = l };
        }

        private async Task<IEnumerable<SearchResult>> SearchBuildings(string queryParam)
        {
            return from b in await _buildingService.GetAllBuldings()

                   let nameMatch = b.Name.ToLower() == queryParam
                   let nameContain = b.Name.ToLower().Contains(queryParam)

                   let descMatch = b.Description.ToLower() == queryParam
                   let descContain = b.Description.ToLower().Contains(queryParam)

                   let shortCutMatch = b.ShortCut.ToLower() == queryParam
                   let shortCutContain = b.ShortCut.ToLower().Contains(queryParam)

                   let score =
                   (nameMatch ? BuildingConstant.Name * 10 : nameContain ? BuildingConstant.Name : 0)
                   + (descMatch ? BuildingConstant.Description * 10 : descContain ? BuildingConstant.Description : 0)
                   + (shortCutMatch ? BuildingConstant.ShortCut * 10 : shortCutContain ? BuildingConstant.ShortCut : 0)
                   where nameMatch || descMatch || nameContain || descContain || shortCutContain || shortCutMatch
                   orderby score descending
                   select new SearchResult { Description = b.Description, Score = score, Name = b.Name, TypeName = Enum.GetName(typeof(ResultType), ResultType.Building), Type = ResultType.Building, Id = b.Id, Building = b };
        }
        private async Task<IEnumerable<SearchResult>> SearchMedia(string queryParam)
        {
            return from m in await _groupService.GetAllMedia()

                   let ownerMatch = m.Owner.ToLower() == queryParam
                   let ownerContain = m.Owner.ToLower().Contains(queryParam)

                   let descMatch = (m.Description != null && m.Description.ToLower() == queryParam)
                   let descContain = (m.Description != null && m.Description.ToLower().Contains(queryParam))

                   let typeMatch = (m.Type != null && m.Type.ToLower() == queryParam)
                   let typeContain = (m.Type != null && m.Type.ToLower().Contains(queryParam))
                   let serialNumberMatch = (m.SerialNumber != null && m.SerialNumber.ToLower() == queryParam)
                   let serialNumberContain = (m.SerialNumber != null && m.SerialNumber.ToLower().Contains(queryParam))
                  

                   let score = (ownerMatch ? MediumConstant.Owner * 10 : ownerContain ? MediumConstant.Owner: 0) + (descMatch ? MediumConstant.Description * 10 : descContain ? MediumConstant.Description : 0)
                   + (typeMatch ? MediumConstant.Type * 10 : typeContain ? MediumConstant.Type : 0)
                   + (serialNumberMatch ? MediumConstant.SerialNumber * 10 : serialNumberContain ? MediumConstant.SerialNumber : 0)
                 

                   where ownerMatch || descMatch || ownerContain || descContain || typeContain || typeMatch || serialNumberMatch || serialNumberContain 
                   orderby score descending
                   select new SearchResult { Description = m.Description, Score = score, Name = "", TypeName = Enum.GetName(typeof(ResultType), ResultType.Medium), Type = ResultType.Medium, Id = m.Id, Medium = m };
        }

        private async Task<IEnumerable<SearchResult>> SearchGroupMedia(string queryParam)
        {
            return from g in await _groupService.GetAllGroups()
                   join m in await _groupService.GetAllMedia() on g.Id equals m.GroupId

                   let nameMatch = g.Name.ToLower() == queryParam
                   let nameContain = g.Name.ToLower().Contains(queryParam)

                   let descMatch =g.Description != null && g.Description.ToLower() == queryParam
                   let descContain = g.Description != null && g.Description.ToLower().Contains(queryParam)

                  



                   let score = (nameMatch ? MediumConstant.GroupConstant.Name * 10 : nameContain ? MediumConstant.GroupConstant.Name : 0)
                   + (descMatch ? MediumConstant.GroupConstant.Description * 10 : descContain ? MediumConstant.GroupConstant.Description : 0)
               
                   where nameMatch || descMatch || nameContain || descContain 
                   orderby score descending
                   select new SearchResult { Description = m.Description, Score = score, Name = "", TypeName = Enum.GetName(typeof(ResultType), ResultType.Medium), Type = ResultType.Medium, Id = m.Id, Medium = m };
        }

        private async Task<IEnumerable<SearchResult>> SearchGroups(string queryParam)
        {
            return from g in await _groupService.GetAllGroups()

                   let nameMatch = g.Name.ToLower() == queryParam
                   let nameContain = g.Name.ToLower().Contains(queryParam)

                   let descMatch = g.Description != null && g.Description.ToLower() == queryParam
                   let descContain = g.Description != null && g.Description.ToLower().Contains(queryParam)

                   

                   let score =
                   (nameMatch ? GroupConstant.Name * 10 : nameContain ? GroupConstant.Name : 0)
                   + (descMatch ? GroupConstant.Description * 10 : descContain ? GroupConstant.Description : 0)
                
                   where nameMatch || descMatch || nameContain || descContain 
                   orderby score descending
                   select new SearchResult { Description = g.Description, Score = score, Name = g.Name, TypeName = Enum.GetName(typeof(ResultType), ResultType.Group), Type = ResultType.Group, Id = g.Id, Group = g };
        }


    }
}
