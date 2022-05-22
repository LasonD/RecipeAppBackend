using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Commands.Register
{
    public class RegisterRequest : IRequest<JwtResponse>
    {
        public RegisterRequest(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
