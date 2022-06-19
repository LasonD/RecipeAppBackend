namespace Domain.Entities
{
    public class Recipe : AbstractEntity
    {
        private readonly List<Ingredient> _ingredients = new();

        public Recipe(string name, string description)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentNullException(nameof(description)) : description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Ingredient> Ingredients => _ingredients;

        public void AddIngredient(string name, decimal quantity, string measureUnit)
        {
            var ingredient = new Ingredient(name, quantity, measureUnit, isInShoppingList: false);

            _ingredients.Add(ingredient);
        }

        public int AuthorId { get; private set; }

        public User Author { get; private set; }
    }
}