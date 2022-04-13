using Domain.Entities;

namespace Domain.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>?> GetRecipesOfUserAsync(int userId);
    }
}
