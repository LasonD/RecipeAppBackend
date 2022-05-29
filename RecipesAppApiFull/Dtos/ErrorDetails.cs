using System.Net;
using Newtonsoft.Json;

namespace RecipesAppApiFull.Dtos
{
    public record ErrorDetails(HttpStatusCode StatusCode, params string[] Messages)
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
