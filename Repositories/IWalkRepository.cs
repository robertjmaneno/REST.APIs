using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalksAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync(string? filterOn=null,
            string? filterQuerry=null, string? sortBy=null, bool isAscending=true, int pageNumber=5,
            int pageSize = 10);
        Task<Walk?> GetWalkById(Guid id);
        Task<Walk?> Update(Guid id, Walk walk);

        Task<Walk?> Delete(Guid id);
    }
}
