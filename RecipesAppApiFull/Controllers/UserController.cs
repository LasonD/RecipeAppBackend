using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Commands.AddToShoppingList;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("shopping-list/{recipeId}")]
        public async Task<IActionResult> AddToShoppingList(int recipeId)
        {
            var userId = 0; // TODO

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
