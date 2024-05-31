using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace REST.APIs.Data
{

    public class AuthenticationDbContext : IdentityDbContext
    {

        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>
            {
                
                new IdentityRole
                {
                    Id = "e1e72a43-a32b-42f9-b913-607dcb893a61",
                    ConcurrencyStamp ="e1e72a43-a32b-42f9-b913-607dcb893a61",
                    Name = "Reader",
                    NormalizedName ="Reader".ToUpper(),
                },
                   new IdentityRole
                {
                    Id = "675b64b4-f6e1-48ab-a81a-354cff7691f5",
                    ConcurrencyStamp ="675b64b4-f6e1-48ab-a81a-354cff7691f5",
                    Name = "Creator",
                    NormalizedName ="Creator".ToUpper(),


                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
            
        }
    }
}
