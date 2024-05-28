using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateWalksAsync(Walk walk);
        Task<List<Walk>> GetAllWalksAsync();

        Task<Walk?> GetWalkById(Guid id);
    }
}
