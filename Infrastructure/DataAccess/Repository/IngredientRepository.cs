using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientsRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>?> GetShoppingListByUserIdAsync(int userId)
        {
            var user = await _context
                .Users
                .Include(x => x.ShoppingList)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.ShoppingList;
        }

        public async Task<IEnumerable<Ingredient>?> GetIngredientsOfRecipeAsync(int recipeId)
        {
            var user = await _context
                .Recipes
                .Include(x => x.Ingredients)
                .FirstOrDefaultAsync(u => u.Id == recipeId);

            return user?.Ingredients;
        }
    }
}
