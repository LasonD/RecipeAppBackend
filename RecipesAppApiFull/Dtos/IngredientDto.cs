namespace RecipesAppApiFull.Dtos
{
    public record IngredientDto(int Id, string Name, decimal Quantity, string MeasureUnit) : DtoBase<int>(Id);
}
