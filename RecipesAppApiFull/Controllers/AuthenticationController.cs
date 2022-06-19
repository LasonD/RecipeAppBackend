using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Application.Commands.Login;
using RecipesAppApiFull.Application.Commands.Register;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginInfo, CancellationToken cancellationToken)
        {
            var request = new LoginCommand(loginInfo.Email, loginInfo.Password);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registrationInfo, CancellationToken cancellationToken)
        {
            var request = new RegisterCommand(
                registrationInfo.UserName,
                registrationInfo.FirstName, 
                registrationInfo.LastName, 
                registrationInfo.Email,
                registrationInfo.Password);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
