using Microsoft.EntityFrameworkCore;
using REST.APIs.Models.Domain;

namespace REST.APIs.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {
        }


        public DbSet<Difficuilty> Difficuilty { get; set;}
        public DbSet<Region> Region { get; set;}

        public DbSet<Walk> Walk { get; set;}
    }
}
