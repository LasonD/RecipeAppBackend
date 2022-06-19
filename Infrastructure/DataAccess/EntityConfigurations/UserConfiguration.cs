using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Metadata.SetNavigationAccessMode(PropertyAccessMode.Property);

            builder
                .HasOne(typeof(AppIdentityUser))
                .WithOne("DomainUser")
                .HasForeignKey(typeof(User));

            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Recipes)
                .WithOne(x => x.Author);

            builder
                .HasMany(x => x.ShoppingList);
        }
    }
}
