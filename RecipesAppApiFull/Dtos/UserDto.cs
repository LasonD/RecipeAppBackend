namespace RecipesAppApiFull.Dtos
{
    public record UserDto(string Id, IEnumerable<RecipeDto> Recipes, IEnumerable<IngredientDto> ShoppingList) : DtoBase<string>(Id);
}
