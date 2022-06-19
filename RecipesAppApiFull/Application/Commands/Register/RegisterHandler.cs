using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Application.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, JwtResponse>
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public RegisterHandler(UserManager<AppIdentityUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<JwtResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var newUser = new AppIdentityUser(command.UserName, command.FirstName, command.LastName, command.Email);

            var identityResult = await _userManager.CreateAsync(newUser, command.Password);

            if (!identityResult.Succeeded)
            {
                throw new UnableToRegisterException(identityResult.Errors.ToArray());
            }

            var token = _jwtGenerator.GenerateToken(newUser);
            var tokenString = _jwtGenerator.FlattenToken(token);

            return new JwtResponse(tokenString, newUser.Email, token.ValidTo, newUser.DomainUser.Id);
        }
    }
}
