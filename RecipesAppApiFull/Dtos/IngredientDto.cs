namespace RecipesAppApiFull.Dtos
{
    public record IngredientDto(int Id, string Name, int Quantity, string MeasureUnit) : DtoBase<int>(Id);
}
