using MediatR;

namespace RecipesAppApiFull.Application.Commands.AddToShoppingList
{
    public record AddToShoppingListCommand(int UserId, int RecipeId) : IRequest;
}