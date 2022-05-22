﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public sealed class AppIdentityUser : IdentityUser
    {
        public AppIdentityUser(string firstName, string lastName, string email)
        {
            UserName = $"{firstName} {lastName}";
            Email = email;
        }

        private User DomainUser { get; set; } = new User();
    }
}
