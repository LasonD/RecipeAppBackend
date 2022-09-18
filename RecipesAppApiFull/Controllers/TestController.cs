using Microsoft.AspNetCore.Mvc;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("hello")]
        [Produces("text/html")]
        public string Test()
        {
            return "<h1 style=\"color: blue;\">Hello World!</h1>";
        }
    }
}
