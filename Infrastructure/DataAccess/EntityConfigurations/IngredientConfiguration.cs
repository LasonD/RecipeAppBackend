using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Metadata.SetNavigationAccessMode(PropertyAccessMode.Property);

            builder.Property(x => x.Quantity)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .HasOne(x => x.Recipe)
                .WithMany(x => x.Ingredients);
        }
    }
}
