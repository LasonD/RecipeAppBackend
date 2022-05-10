using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Metadata.SetNavigationAccessMode(PropertyAccessMode.Property);

            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Ingredients)
                .WithOne(x => x.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired();
        }
    }
}
