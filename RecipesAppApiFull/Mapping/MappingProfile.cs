using AutoMapper;
using Domain.Entities;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<User, UserDto>();
        }
    }
}
