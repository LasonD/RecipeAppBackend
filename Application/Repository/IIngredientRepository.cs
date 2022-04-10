using Domain.Entities;

namespace Application.Repository
{
    public interface IIngredientsRepository : IRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetUserShoppingListAsync(int userId);
    }
}
