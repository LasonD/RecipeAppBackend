using MediatR;

namespace RecipesAppApiFull.Commands.AddToShoppingList
{
    public class AddToShoppingListRequest : IRequest
    {
        public AddToShoppingListRequest(int userId, int recipeId)
        {
            UserId = userId;
            RecipeId = recipeId;
        }

        public int UserId { get; private set; }
        public int RecipeId { get; private set; }
    }
}
