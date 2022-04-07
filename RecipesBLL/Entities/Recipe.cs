namespace Domain.Entities
{
    public class Recipe : AbstractEntity
    {
        private List<Ingredient> _ingredients = new();

        public Recipe(string name, string description)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            Description = string.IsNullOrWhiteSpace(description) ? throw new ArgumentNullException(nameof(description)) : description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyCollection<Ingredient> Ingredients => _ingredients;

        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));

            _ingredients.Add(ingredient);
        }
    }
}