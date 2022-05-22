using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Commands.AddToShoppingList;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("shopping-list/{recipeId}")]
        public async Task<IActionResult> AddToShoppingList(int recipeId)
        {
            // TODO refactor
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var userId = int.Parse(identity?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            var request = new AddToShoppingListRequest(userId, recipeId);

            try
            {
                await _mediator.Send(request);

                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
