using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public sealed class AppIdentityUser : IdentityUser
    {
        public AppIdentityUser()
        {

        }

        public AppIdentityUser(string userName, string firstName, string lastName, string email)
        {
            UserName = userName;
            NormalizedUserName = userName.ToUpper();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NormalizedEmail = email.ToUpper();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User DomainUser { get; private set; } = new User();
    }
}
