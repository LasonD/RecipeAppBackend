namespace RecipesAppApiFull.Dtos
{
    public abstract class DtoBase<TId>
    {
        public TId Id { get; set; }
    }
}
