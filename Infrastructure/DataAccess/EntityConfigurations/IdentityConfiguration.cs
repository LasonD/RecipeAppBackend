using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations
{
    public class IdentityConfiguration : IEntityTypeConfiguration<AppIdentityUser>
    {
        public void Configure(EntityTypeBuilder<AppIdentityUser> builder)
        {
            builder
                .HasOne(x => x.DomainUser)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Navigation(x => x.DomainUser)
                .AutoInclude();
        }
    }
}
