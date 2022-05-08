using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recipe>?> GetRecipesOfUserAsync(int userId)
        {
            var user = await _context
                .Users
                .Include(x => x.Recipes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Recipes;
        }
    }
}
