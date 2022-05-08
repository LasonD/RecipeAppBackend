namespace Infrastructure.Dtos
{
    public record RecipeDto(string Name, IEnumerable<IngredientDto> Ingredients);
}
