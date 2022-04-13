using Domain.Services;
using MediatR;

namespace Application.Commands.AddToShoppingList
{
    public class AddToShoppingListHandler : IRequestHandler<AddToShoppingListRequest>
    {
        private readonly IAddToShoppingListService _addToShoppingListService;

        public AddToShoppingListHandler(IAddToShoppingListService addToShoppingListService)
        {
            _addToShoppingListService = addToShoppingListService;
        }

        public async Task<Unit> Handle(AddToShoppingListRequest request, CancellationToken cancellationToken)
        {
            await _addToShoppingListService.AddToShoppingListAsync(request.UserId, request.RecipeId);

            return Unit.Value;
        }
    }
}
