using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Commands.AddToShoppingList
{
    public record AddToShoppingListCommand(int UserId, int RecipeId) : IRequest<IEnumerable<IngredientDto>>;
}