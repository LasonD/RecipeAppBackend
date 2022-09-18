using System.ComponentModel.DataAnnotations;

namespace RecipesAppApiFull.Dtos
{
    public record IngredientDto(int Id,  [Required] string Name,  decimal Quantity, [Required] string MeasureUnit) : IdentifiedDtoBase<int>(Id);
}
