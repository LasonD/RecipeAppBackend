using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] RecipeDto recipe)
        {
            var recipeEntity = new Recipe(recipe.Name, recipe.Description);

            foreach (var i in recipe.Ingredients)
            {
                recipeEntity.AddIngredient(i.Name, i.Quantity, i.MeasureUnit);
            }

            var createdRecipe = await _recipeRepository.AddAsync(recipeEntity);

            await _recipeRepository.SaveChangesAsync();

            return Created($"recipes/{createdRecipe.Id}", createdRecipe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            return Ok(await _recipeRepository.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return Ok(await _recipeRepository.Query().ToListAsync());
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
