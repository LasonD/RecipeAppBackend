using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<JwtResponse>;
}
