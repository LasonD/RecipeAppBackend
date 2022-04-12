using Domain.Entities;

namespace Application.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetRecipesOfUserAsync(int userId);
    }
}
