using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<Ingredient>?> AddToShoppingListAsync(int userId, IEnumerable<Ingredient> ingredients);
    }
}
