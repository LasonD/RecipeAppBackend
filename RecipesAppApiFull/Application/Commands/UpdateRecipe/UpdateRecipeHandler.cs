using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.UpdateRecipe
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeCommand, RecipeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public UpdateRecipeHandler(IMapper mapper, IRecipeRepository recipeRepository)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeDto> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.GetByIdAsync(request.RecipeId);

            if (recipe == null)
            {
                throw new EntityNotFoundException(nameof(Recipe), request.RecipeId);
            }

            if (recipe.AuthorId != request.UserId)
            {
                throw new AccessForbiddenException("You don't have rights to update this recipe");
            }

            _mapper.Map<reques>
        }
    }
}
