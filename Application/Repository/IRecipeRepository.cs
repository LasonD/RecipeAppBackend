using Domain.Entities;

namespace Application.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetUserRecipesAsync(int userId);
        Task<IEnumerable<Ingredient>> GetRecipeIngredientsAsync(int recipeId);

    }
}
