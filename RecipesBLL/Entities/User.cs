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

        public Recipe CreateRecipe(string name, string description, string imageUrl, IEnumerable<Ingredient>? ingredients = null)
        {
            if (_recipes.Any(r => r.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new ArgumentException($"User already has recipe with name '{name}'");
            }

            var recipe = new Recipe(name, description);

            foreach (var ingredient in ingredients ?? Enumerable.Empty<Ingredient>())
            {
                recipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.MeasureUnit);
            }

            _recipes.Add(recipe);

            return recipe;
        }
    }
}
