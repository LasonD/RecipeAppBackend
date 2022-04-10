namespace RecipesAppApiFull.Dtos
{
    public class UserDto : DtoBase<string>
    {
        public IEnumerable<RecipeDto> Recipes { get; set; }
        public IEnumerable<IngredientDto> ShoppingList { get; set;}
    }
}
