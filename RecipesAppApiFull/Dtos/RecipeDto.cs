using System.ComponentModel.DataAnnotations;

namespace RecipesAppApiFull.Dtos
{
    public record RecipeDto(int Id, [Required] string Name, [Required] string Description, string ImageUrl, IEnumerable<IngredientDto> Ingredients) : IdentifiedDtoBase<int>(Id);
}
