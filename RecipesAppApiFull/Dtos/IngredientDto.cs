namespace RecipesAppApiFull.Dtos
{
    public class IngredientDto : DtoBase<int>
    {
        public string Name { get; set; }
        public string MeasureUnit { get; set; }
        public decimal Quantity { get; set; }
        public bool IsInShoppingList { get; set; }
    }
}
