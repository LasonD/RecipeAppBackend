using MediatR;

namespace RecipesAppApiFull.Dtos
{
    public record LoginDto(string Email, string Password);
}
