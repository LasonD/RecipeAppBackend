using MediatR;

namespace Application.Commands.AddToShoppingList
{
    public class AddToShoppingListHandler : IRequestHandler<AddToShoppingListRequest>
    {
        public Task<Unit> Handle(AddToShoppingListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
