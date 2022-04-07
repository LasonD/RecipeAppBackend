using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class RecipesAppIdentityUser : IdentityUser
    {
        public User ApplicationUser { get; private set; }
    }
}
