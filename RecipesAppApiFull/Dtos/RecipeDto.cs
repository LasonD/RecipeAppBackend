namespace RecipesAppApiFull.Dtos
{
    public record RecipeDto(int Id, string Name, IEnumerable<IngredientDto> Ingredients) : DtoBase<int>(Id);
}
