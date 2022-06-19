using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.AddToShoppingList
{
    public class AddToShoppingListHandler : IRequestHandler<AddToShoppingListCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;

        public AddToShoppingListHandler(IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<Unit> Handle(AddToShoppingListCommand command, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetByIdAsync(command.RecipeId);

            if (recipe == null)
            {
                throw new EntityNotFoundException(nameof(Recipe), command.RecipeId);
            }

            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), command.UserId);
            }

            user.AddToShoppingList(recipe.Ingredients);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
