﻿using Application.Exceptions;
using Application.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recipe>> GetUserRecipesAsync(int userId)
        {
            var user = await _context
                .Users
                .Include(x => x.Recipes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) throw new EntityNotFoundException<User>(userId);

            return user.Recipes;
        }

        public async Task<IEnumerable<Ingredient>> GetRecipeIngredientsAsync(int recipeId)
        {
            var user = await _context
                .Recipes
                .Include(x => x.Ingredients)
                .FirstOrDefaultAsync(u => u.Id == recipeId);

            if (user == null) throw new EntityNotFoundException<Recipe>(recipeId);

            return user.Ingredients;
        }
    }
}
