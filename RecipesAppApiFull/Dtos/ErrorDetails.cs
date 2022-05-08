using System.Net;
using Newtonsoft.Json;

namespace RecipesAppApiFull.Dtos
{
    public record ErrorDetails(HttpStatusCode StatusCode, string Message)
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
