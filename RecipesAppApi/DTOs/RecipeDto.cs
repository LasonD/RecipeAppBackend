namespace RecipesAppApi.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
