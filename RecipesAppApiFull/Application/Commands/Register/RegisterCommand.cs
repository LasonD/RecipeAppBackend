using MediatR;
using RecipesAppApiFull.Dtos;

namespace RecipesAppApiFull.Application.Commands.Register
{
    public class RegisterCommand : IRequest<JwtResponse>
    {
        public RegisterCommand(string userName, string firstName, string lastName, string email, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string UserName { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
