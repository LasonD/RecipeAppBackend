using Domain.Entities;

namespace Application.Repository
{
    public interface IIngredientsRepository : IRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetShoppingListByUserIdAsync(int userId);
        Task<IEnumerable<Ingredient>> GetIngredientsOfRecipeAsync(int recipeId);
    }
}
