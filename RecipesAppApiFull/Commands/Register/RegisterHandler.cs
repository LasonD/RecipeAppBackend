using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RecipesAppApiFull.Commands.Login;
using RecipesAppApiFull.Dtos;
using RecipesAppApiFull.Exceptions;

namespace RecipesAppApiFull.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, JwtResponse>
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public async Task<JwtResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var newUser = new AppIdentityUser(request.FirstName, request.LastName, request.Email);

            var identityResult = await _userManager.CreateAsync(newUser, request.Password);

            if (!identityResult.Succeeded)
            {
                throw new UnableToRegisterException(identityResult.Errors.ToArray());
            }



            if (user == null)
            {
                throw new EntityNotFoundException("user", request.Email);
            }

            var credentialsAreCorrect = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!credentialsAreCorrect)
            {
                throw new EntityNotFoundException("user", request.Email);
            }

            var (token, expiresIn) = _jwtGenerator.GenerateToken(user);

            return new JwtResponse(token, expiresIn, new[] { "User" });
        }
    }
}
