namespace RecipesAppApi.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string AmountMeasure { get; set; }
    }
}
