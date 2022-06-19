using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Commands.CreateRecipe
{
    public record CreateRecipeCommand(int UserId, RecipeDto Recipe) : IRequest<RecipeDto>;
}
