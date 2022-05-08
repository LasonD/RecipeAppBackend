using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IIngredientsRepository : IRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>?> GetShoppingListByUserIdAsync(int userId);
        Task<IEnumerable<Ingredient>?> GetIngredientsOfRecipeAsync(int recipeId);
    }
}
