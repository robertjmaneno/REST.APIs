using Microsoft.EntityFrameworkCore;
using REST.APIs.Data;
using REST.APIs.Models.Domain;

namespace REST.APIs.Repositories
{
    public class SQLRegionRepository(ApplicationDbContext applicationDbContext) : IRegionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<Region> CreateAsync(Region region)
        {
            await _applicationDbContext.Region.AddAsync(region);
            await _applicationDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _applicationDbContext.Region.FindAsync(id);
            if (existingRegion == null)
            {
                throw new ArgumentException("Region not found");
            }
            _applicationDbContext.Region.Remove(existingRegion);
            await _applicationDbContext.SaveChangesAsync();
            return existingRegion;
        }


        public async Task<List<Region>> GetAllAsync()
        {
            var regions = await _applicationDbContext.Region.ToListAsync();
            return regions;
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            var region = await _applicationDbContext.Region.FirstOrDefaultAsync(u=>u.Id == id);

            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _applicationDbContext.Region.FindAsync(id);
            if (existingRegion == null)
            {
                throw new ArgumentException("Region not found");
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _applicationDbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
