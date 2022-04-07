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

            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Recipe);
        }
    }
}
