using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, JwtResponse>
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public RegisterHandler(UserManager<AppIdentityUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<JwtResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var newUser = new AppIdentityUser(request.FirstName, request.LastName, request.Email);

            var identityResult = await _userManager.CreateAsync(newUser, request.Password);

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
