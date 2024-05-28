using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using REST.APIs.Data;
using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SQLWalkRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Walk> CreateWalksAsync(Walk walk)
        {
             await _applicationDbContext.Walk.AddAsync(walk);
            await _applicationDbContext.SaveChangesAsync();

            return walk;
           
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
           var walks = await  _applicationDbContext.Walk.Include("Difficuilty").Include("Region").ToListAsync();

            return walks;
        }

        public async Task<Walk?> GetWalkById(Guid id)
        {
            var walk = await _applicationDbContext.Walk.Include("Difficuilty").
                Include("Region").FirstOrDefaultAsync(u=>u.Id == id);

            if (walk == null)
            {
                return null;
            }

            return walk;
        }
    }
}
