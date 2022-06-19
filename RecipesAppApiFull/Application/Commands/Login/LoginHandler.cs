using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, JwtResponse>
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginHandler(UserManager<AppIdentityUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<JwtResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user == null)
            {
                throw new EntityNotFoundException("user", command.Email);
            }

            var credentialsAreCorrect = await _userManager.CheckPasswordAsync(user, command.Password);

            if (!credentialsAreCorrect)
            {
                throw new EntityNotFoundException("user", command.Email);
            }

            var token = _jwtGenerator.GenerateToken(user);
            var tokenString = _jwtGenerator.FlattenToken(token);

            return new JwtResponse(tokenString, user.Email, token.ValidTo, user.DomainUser.Id);
        }
    }
}
