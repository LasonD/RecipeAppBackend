using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.CreateRecipe
{
    public class CreateRecipeHandler : IRequestHandler<CreateRecipeCommand, RecipeDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateRecipeHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RecipeDto> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request.UserId);
            }

            var newRecipe = user.CreateRecipe(request.Recipe.Name, request.Recipe.Description);

            foreach (var ingredient in request.Recipe.Ingredients)
            {
                newRecipe.AddIngredient(ingredient.Name, ingredient.Quantity, ingredient.MeasureUnit);
            }

            await _userRepository.SaveChangesAsync();

            return _mapper.Map<Recipe, RecipeDto>(newRecipe);
        }
    }
}
