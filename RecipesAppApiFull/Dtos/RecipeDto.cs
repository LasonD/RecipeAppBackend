namespace RecipesAppApiFull.Dtos
{
    public class RecipeDto : DtoBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set;}
    }
}
