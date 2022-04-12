namespace Domain.Services
{
    public interface IAddToShoppingListService
    {
        Task AddToShoppingList(int userId, int recipeId);
    }

    public class AddToShoppingListService : IAddToShoppingListService
    {
        private readonly IUserRepository

        public Task AddToShoppingList(int userId, int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
