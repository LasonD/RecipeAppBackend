using Infrastructure.DataAccess.EntityConfigurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class RecipesAppIdentityDbContext : IdentityDbContext<RecipesAppIdentityUser>
    {
        public RecipesAppIdentityDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<RecipesAppIdentityUser> Identities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new IdentityConfiguration());
        }
    }
}
