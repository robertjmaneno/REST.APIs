using Microsoft.EntityFrameworkCore;
using REST.APIs.Models.Domain;
using System.Linq.Expressions;

namespace REST.APIs.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            dbContextOptions) : base(dbContextOptions) {
        }

        public DbSet<Difficuilty> Difficuilty { get; set;}
        public DbSet<Region> Region { get; set;}

        public DbSet<Image> Images { get; set;}

        public DbSet<Walk> Walk { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficuities = new List<Difficuilty>()
            {
                new Difficuilty()
                {
                    Id = Guid.Parse("1adcc4ef-379d-40bb-9e7c-71dcd7586a0c"),
                    Name = "Easy"
                },

                new Difficuilty()
                {
                    Id = Guid.Parse("9544d9fb-4c4f-4469-a224-e134d10080a8"),
                    Name = "Medium"
                },

                new Difficuilty()
                {
                    Id = Guid.Parse("122bed92-bf29-4999-8c8b-1eb360a5f44c"),
                    
                    Name = "Hard"
                },

                new Difficuilty()
                {
                    Id = Guid.Parse("8ebc17c8-3fd9-4765-afb7-26f79ee279fb"),

                    Name = "Very Hard"
                }

            };

            var regions = new List<Region>()
            {
                 new Region
                 {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                 },

                 new Region
                 {
                      Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                 }
                 ,
                  new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
            };

            modelBuilder.Entity<Difficuilty>().HasData(difficuities);
            modelBuilder.Entity<Region>().HasData(regions);
        }



    }

    
}
