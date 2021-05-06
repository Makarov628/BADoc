using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BADoc.UseCases.Utils
{
    public static class IdentityUserServiceExtensions
    {
        public static void AddDefaultAdminUserIfNeeded(this UserManager<IdentityUser> userManager, string email, string password)
        {
            if (!userManager.Users.Any(user => user.Email == email))
            {
                userManager.CreateAsync(new IdentityUser() { Email = email, UserName = email }, password).Wait();
            }
        }
    }
}