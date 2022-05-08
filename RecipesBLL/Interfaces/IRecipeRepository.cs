using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>?> GetRecipesOfUserAsync(int userId);
    }
}
