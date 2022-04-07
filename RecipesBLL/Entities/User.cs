namespace Domain.Entities
{
    public class User : AbstractEntity
    {
        private List<Ingredient> _shoppingList = new();
        private List<Recipe> _recipes = new();

        public IReadOnlyCollection<Ingredient> ShoppingList => _shoppingList;

        public IReadOnlyCollection<Recipe> Recipes => _recipes;
    }
}
