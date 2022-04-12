namespace Domain.Entities
{
    public class User : AbstractEntity
    {
        private List<Ingredient> _shoppingList = new();
        private List<Recipe> _recipes = new();

        public IReadOnlyCollection<Ingredient> ShoppingList => _shoppingList;

        public IReadOnlyCollection<Recipe> Recipes => _recipes;

        public void AddToShoppingList(IEnumerable<Ingredient> ingredients)
        {
            if (ingredients == null) throw new ArgumentNullException(nameof(ingredients));

            var ingredientsArr = ingredients.ToArray();

            foreach (var ingredient in ingredientsArr)
            {
                ingredient.IsInShoppingList
            }  

            _shoppingList.AddRange(ingredients);
        }
    }
}
