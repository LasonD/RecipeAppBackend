using Application.Exceptions;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>?> AddToShoppingListAsync(int userId, IEnumerable<Ingredient> ingredients)
        {
            var user = await _context
                .Users
                .Include(x => x.ShoppingList)
                .FirstOrDefaultAsync(x => x.Id == userId);

            var ingredientsArr = ingredients.ToArray();

            user?.AddToShoppingList(ingredientsArr);

            return user?.ShoppingList;
        }
    }
}
