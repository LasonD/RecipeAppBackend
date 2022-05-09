using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public Task<IActionResult> Login([FromBody] LoginDto loginInfo)
        {
            return null;
        }

        [HttpPost("register")]
        public Task<IActionResult> Register([FromBody] RegistrationDto registrationInfo)
        {
            return null;
        }
    }
}
