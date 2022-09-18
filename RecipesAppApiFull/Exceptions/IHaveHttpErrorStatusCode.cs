using System.Net;

namespace RecipesAppApiFull.Exceptions
{
    public interface IHaveHttpErrorStatusCode
    {
        HttpStatusCode StatusCode { get; };
    }
}
