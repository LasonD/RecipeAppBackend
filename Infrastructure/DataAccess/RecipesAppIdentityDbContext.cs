using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class RecipesAppIdentityDbContext : IdentityDbContext<RecipesAppIdentityUser>
    {
        public DbSet<RecipesAppIdentityUser> Identities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
