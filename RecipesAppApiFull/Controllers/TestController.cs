using Microsoft.AspNetCore.Mvc;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("hello")]
        public IActionResult Test()
        {
            return Content("<h1 style=\"color: blue;\">Hello World!</h1>", "text/html");
        }
    }
}
