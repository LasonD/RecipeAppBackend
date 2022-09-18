using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAppApiFull.Application.Commands.AddToShoppingList;
using RecipesAppApiFull.Application.Commands.CreateRecipe;
using RecipesAppApiFull.Application.Queries.GetUserRecipes;
using RecipesAppApiFull.Dtos;
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

        [HttpGet("recipes")]
        public async Task<IActionResult> GetRecipes([FromQuery] bool withIngredients = true, CancellationToken cancellationToken = default)
        {
            var userId = this.RetrieveUserId();

            var request = new GetUserRecipesQuery(userId, withIngredients);

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        [HttpPost("recipes")]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipeDto recipe, CancellationToken cancellationToken)
        {
            var userId = this.RetrieveUserId();

            var request = new CreateRecipeCommand(userId, recipe);

            await _mediator.Send(request, cancellationToken);

            return Ok();
        }

        [HttpPut("recipes/{id}")]
        public async Task<IActionResult> UpdateRecipe(int recipeId, [FromBody] RecipeDto recipe, CancellationToken cancellationToken)
        {
            var userId = this.RetrieveUserId();

            var request = new CreateRecipeCommand(userId, recipe);

            await _mediator.Send(request, cancellationToken);

            return Ok();
        }

        [HttpPost("shopping-list/{recipeId}")]
        public async Task<IActionResult> AddToShoppingList(int recipeId, CancellationToken cancellationToken)
        {
            var userId = this.RetrieveUserId();

            var request = new AddToShoppingListCommand(userId, recipeId);

            var shoppingList = await _mediator.Send(request, cancellationToken);

            return Ok(shoppingList);
        }
    }
}