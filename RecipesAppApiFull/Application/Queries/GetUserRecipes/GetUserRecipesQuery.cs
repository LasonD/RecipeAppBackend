using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Queries.GetUserRecipes
{
    // TODO: add pagination, filtering support
    public class GetUserRecipesQuery : IRequest<IEnumerable<RecipeDto>>, IRequest<Unit>
    {
        public GetUserRecipesQuery(int userId, bool includeIngredients)
        {
            UserId = userId;
            IncludeIngredients = includeIngredients;
        }

        public int UserId { get; private set; }

        public bool IncludeIngredients { get; private set; }
    }
}
