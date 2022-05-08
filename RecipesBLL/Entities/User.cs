namespace Domain.Entities
{
    public class User : AbstractEntity
    {
        private List<Ingredient> _shoppingList = new();
        private List<Recipe> _recipes = new();

        public IReadOnlyCollection<Ingredient> ShoppingList => _shoppingList;

        public IReadOnlyCollection<Recipe> Recipes => _recipes;

        public void AddToShoppingList(IEnumerable<Ingredient> ingredientsToAdd)
        {
            if (ingredientsToAdd == null) throw new ArgumentNullException(nameof(ingredientsToAdd));

            var ingredientsArr = ingredientsToAdd.ToArray();

            foreach (var ingredient in ingredientsArr)
            {
                var shoppingListIngredient = (Ingredient)ingredient.Clone();

                shoppingListIngredient.IsInShoppingList = true;

                _shoppingList.Add(shoppingListIngredient);
            }
        }
    }
}
