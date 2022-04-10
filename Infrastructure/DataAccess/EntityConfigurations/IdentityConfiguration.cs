using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations
{
    public class IdentityConfiguration : IEntityTypeConfiguration<RecipesAppIdentityUser>
    {
        public void Configure(EntityTypeBuilder<RecipesAppIdentityUser> builder)
        {
            builder
                .HasOne(x => x.ApplicationUser)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
