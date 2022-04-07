namespace Domain.Entities
{
    public class Ingredient : AbstractEntity
    {
        public Ingredient(string name, decimal quantity, string measureUnit)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
            MeasureUnit = string.IsNullOrWhiteSpace(measureUnit) ? throw new ArgumentNullException(nameof(measureUnit)) : measureUnit;
            Quantity = quantity;
        }

        public string Name { get; private set; }

        public decimal Quantity { get; private set; }

        public string MeasureUnit { get; private set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; private set; }
    }
}