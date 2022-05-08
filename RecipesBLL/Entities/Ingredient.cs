namespace Domain.Entities
{
    public class Ingredient : AbstractEntity, ICloneable
    {
        public Ingredient(string name, decimal quantity, string measureUnit, bool isInShoppingList = false)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            MeasureUnit = string.IsNullOrWhiteSpace(measureUnit) ? throw new ArgumentNullException(nameof(measureUnit)) : measureUnit;
            Quantity = quantity;
            IsInShoppingList = isInShoppingList;
        }

        public string Name { get; private set; }

        public decimal Quantity { get; private set; }

        public string MeasureUnit { get; private set; }

        public bool IsInShoppingList { get; set; }

        public int RecipeId { get; private set; }

        public Recipe Recipe { get; private set; }

        public object Clone() => new Ingredient(Name, Quantity, MeasureUnit);
    }
}