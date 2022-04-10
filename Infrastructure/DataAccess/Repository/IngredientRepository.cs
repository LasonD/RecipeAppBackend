using Application.Exceptions;
using Application.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientsRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>> GetUserShoppingListAsync(int userId)
        {
            var user = await _context
                .Users
                .Include(x => x.ShoppingList)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) throw new EntityNotFoundException<User>(userId);

            return user.ShoppingList;
        }
    }
}
