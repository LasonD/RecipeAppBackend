using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Commands.Login
{
    public record LoginRequest(string Email, string Password) : IRequest<JwtResponse>;
}
