using Microsoft.AspNetCore.Mvc;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("hello")]
        public string Test()
        {
            return "Hello World!";
        }
    }
}
