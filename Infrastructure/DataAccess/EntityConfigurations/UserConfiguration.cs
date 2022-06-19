using Domain.Entities;
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
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Recipes)
                .WithOne(x => x.Author);

            builder
                .HasMany(x => x.ShoppingList);
        }
    }
}
