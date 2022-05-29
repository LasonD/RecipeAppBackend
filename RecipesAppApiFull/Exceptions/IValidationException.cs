namespace RecipesAppApiFull.Exceptions
{
    public interface IValidationException
    {
        IEnumerable<string> Errors { get; }
    }
}
