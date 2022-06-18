using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Queries.GetUserRecipes
{
    public class GetUserRecipesQueryHandler : IRequestHandler<GetUserRecipesQuery, IEnumerable<RecipeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public GetUserRecipesQueryHandler(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDto>> Handle(GetUserRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipesOfUserAsync(request.UserId);

            if (recipes == null)
            {
                throw new EntityNotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<IEnumerable<Recipe>, IEnumerable <RecipeDto>>(recipes);
        }
    }
}
