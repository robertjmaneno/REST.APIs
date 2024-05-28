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

        public async Task<Walk?> Delete(Guid id)
        {
           var walkModel = await _applicationDbContext.Walk.FirstOrDefaultAsync(x => x.Id == id);
            if (walkModel == null)
            {
                return null;
            }
            _applicationDbContext.Remove(walkModel);
            _applicationDbContext.SaveChanges();

            return walkModel;

        }

        public Task<Walk?> Delete(Guid id, Walk walk)
        {
            throw new NotImplementedException();
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

        public async Task<Walk?> Update(Guid id, Walk walk)
        {
            var existingWalk = await _applicationDbContext.Walk.FindAsync(id);
            
            if(existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.DifficuiltyId = walk.DifficuiltyId;
            existingWalk.RegionId = walk.RegionId;

            await _applicationDbContext.SaveChangesAsync();


            return(existingWalk);
        }
    }
}
