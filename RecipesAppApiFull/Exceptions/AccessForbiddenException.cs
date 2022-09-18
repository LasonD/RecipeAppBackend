using System.Net;

namespace RecipesAppApiFull.Exceptions
{
    public class AccessForbiddenException : Exception, IHaveHttpErrorStatusCode
    {
        public AccessForbiddenException(string message) : base(message)
        {

        }

        public HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
    }
}
