using Infrastructure.DataAccess.EntityConfigurations;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public sealed class RecipesAppIdentityDbContext : IdentityDbContext<AppIdentityUser>
    {
        public RecipesAppIdentityDbContext(DbContextOptions<RecipesAppIdentityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AppIdentityUser> Identities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new IdentityConfiguration());
        }
    }
}
