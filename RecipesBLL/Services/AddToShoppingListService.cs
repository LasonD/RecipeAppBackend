using Domain.Entities;
using Domain.Repository;

namespace Domain.Services
{
    public interface IAddToShoppingListService
    {
        Task AddToShoppingListAsync(int userId, int recipeId);
    }

    public class AddToShoppingListService : IAddToShoppingListService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIngredientsRepository _ingredientsRepository;

        public AddToShoppingListService(IUserRepository userRepository, IIngredientsRepository ingredientsRepository)
        {
            _userRepository = userRepository;
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task AddToShoppingListAsync(int userId, int recipeId)
        {
            var recipeIngredients = await _ingredientsRepository.GetIngredientsOfRecipeAsync(recipeId);

            var shoppingListIngredients = recipeIngredients
                .Select(x => new Ingredient(
                    x.Name,
                    x.Quantity,
                    x.MeasureUnit,
                    isInShoppingList: true
                ));


        }
    }
}
