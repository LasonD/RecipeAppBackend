using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<Ingredient>?> AddToShoppingListAsync(int userId, IEnumerable<Ingredient> ingredients);
    }
}
