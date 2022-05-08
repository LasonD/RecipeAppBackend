using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IIngredientsRepository _ingredientsRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController(IIngredientsRepository ingredientsRepository, IRecipeRepository recipeRepository)
        {
            _ingredientsRepository = ingredientsRepository;
            _recipeRepository = recipeRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetRecipes(int recipeId)
        //{
        //    var ingredients = await _recipeRepository.Query().ToListAsync();

        //    if (ingredients == null) return NotFound();

        //    return Ok(ingredients);
        //}

        [HttpGet("{recipeId}/ingredients")]
        public async Task<IActionResult> GetIngredients(int recipeId)
        {
            var ingredients = await _ingredientsRepository.GetIngredientsOfRecipeAsync(recipeId);

            if (ingredients == null) return NotFound();

            return Ok(ingredients);
        }
    }
}
