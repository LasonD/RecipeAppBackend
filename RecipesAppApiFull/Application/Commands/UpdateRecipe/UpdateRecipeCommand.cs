using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Commands.UpdateRecipe
{
    public record UpdateRecipeCommand(int UserId, int RecipeId, RecipeDto UpdatedRecipe) : IRequest<RecipeDto>;
}
