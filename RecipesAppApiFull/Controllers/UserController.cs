using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Application.Commands.AddToShoppingList;
using RecipesAppApiFull.Application.Queries.GetUserRecipes;
using RecipesAppApiFull.Helpers;

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

        [HttpGet]
        public async Task<IActionResult> GetRecipes([FromQuery] bool withIngredients = true, CancellationToken cancellationToken = default)
        {
            var userId = this.RetrieveUserId();

            var request = new GetUserRecipesQuery(userId, withIngredients);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpPost("shopping-list/{recipeId}")]
        public async Task<IActionResult> AddToShoppingList(int recipeId, CancellationToken cancellationToken)
        {
            var userId = this.RetrieveUserId();

            var request = new AddToShoppingListRequest(userId, recipeId);

            await _mediator.Send(request, cancellationToken);

            return Ok();
        }
    }
}