using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using REST.APIs.Data;
using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public class SQLWalkRepository(ApplicationDbContext applicationDbContext) : IWalkRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

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

        public async Task<List<Walk>> GetAllWalksAsync(string? filterOn =null, string? filterQuerry =null,
            string? sortBy=null, 
            bool IsAscending = true, int pageNumber = 5,
            int pageSize = 10)
        {


            //Filtering 
            var walks= _applicationDbContext.Walk.Include("Difficuilty").Include("Region").AsQueryable();

          if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuerry) == false) { 
             
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(u => u.Name.Contains(filterQuerry));
                }
            
            }

          //sorting by name and walklength in km

          if(string.IsNullOrWhiteSpace(sortBy) == false){
             
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(u => u.Name) : walks.OrderByDescending(u => u.Name);
                }
                else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = IsAscending ? walks.OrderBy(u => u.LengthInKm) :
                        walks.OrderByDescending(u => u.LengthInKm);
                }

            }


          //pagination

            var skipResults = (pageSize - 1) * pageNumber;



            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
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
