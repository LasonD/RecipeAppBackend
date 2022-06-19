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

        public async Task<IEnumerable<Recipe>?> GetRecipesOfUserAsync(int userId, bool withIngredients, CancellationToken cancellationToken)
        {
            User? user;

            var baseQuery = _context
                .Users
                .Include(x => x.Recipes);

            if (withIngredients)
            {
                user = await baseQuery
                    .ThenInclude(x => x.Ingredients)
                    .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            }
            else
            {
                user = await baseQuery
                    .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            }

            return user?.Recipes;
        }
    }
}
