namespace RecipesAppApiFull.Dtos
{
    public record RecipeDto(int Id, string Name, string Description, IEnumerable<IngredientDto> Ingredients) : IdentifiedDtoBase<int>(Id);
}
