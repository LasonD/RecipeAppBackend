using Domain.Interfaces;

namespace RecipesAppApiFull.Commands.AddToShoppingList
{
    public class AddToShoppingListHandler : IRequestHandler<AddToShoppingListRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;

        public AddToShoppingListHandler(IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<Unit> Handle(AddToShoppingListRequest request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

            if (recipe == null)
            {
                throw new ArgumentException($"Recipe with id {request.RecipeId} not found");
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {request.UserId} not found");
            }

            user.AddToShoppingList(recipe.Ingredients);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
