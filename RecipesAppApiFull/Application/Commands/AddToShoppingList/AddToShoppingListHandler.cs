using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.AddToShoppingList
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
                throw new EntityNotFoundException(nameof(Recipe), request.RecipeId);
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request.UserId);
            }

            user.AddToShoppingList(recipe.Ingredients);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
