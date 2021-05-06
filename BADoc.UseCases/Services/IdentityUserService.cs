using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using BADoc.UseCases.DTO;
using BADoc.UseCases.Utils;
using BADoc.UseCases.Interfaces;
using BADoc.Infrastructure.Interfaces;
using BADoc.UseCases.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BADoc.UseCases.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly string adminEmail;
        public IdentityUserService(UserManager<IdentityUser> userManager, IConfiguration configuration) 
        {
            _userManager = userManager;

            // Добавляем пользователя по умолчанию
            // Временное решение, в будущем нужно переходить на использование ролей 
            adminEmail = configuration.GetSection("AdminUser:Email").Value;
            string password = configuration.GetSection("AdminUser:Password").Value;
            _userManager.AddDefaultAdminUserIfNeeded(adminEmail, password);
        }

        private void CheckAndThrowIdentityErrors(IdentityResult result)
        {
            if (result.Errors.Any())
            {
                List<string> errorsDescription = result.Errors
                    .Select(err => err.Description)
                    .ToList();

                string message = string.Join("; ", errorsDescription);

                throw new UserValidationException(message);
            }
        }
        
        private async Task<IdentityUser> GetUserByEmail(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(user => 
                user.Email.ToLower() == email.ToLower()
            );
        }

        private async Task<IdentityUser> GetUserByCredentials(string email, string password)
        {
            IdentityUser user = await GetUserByEmail(email);    
        
            if (user == null)
            {
                throw new CheckCredentialsException();
            }
            
            bool passwordIsCorrect = await _userManager.CheckPasswordAsync(user, password);
            
            if(!passwordIsCorrect)
            {
                throw new CheckCredentialsException();
            };

            return user;
        }

        public async Task ChangePassword(UpdateUserPasswordDTO userPasswordDTO)
        {
            IdentityUser user = await GetUserByCredentials(userPasswordDTO.Email, userPasswordDTO.OldPassword);

            IdentityResult result = await _userManager.ChangePasswordAsync(
                user, 
                userPasswordDTO.OldPassword, 
                userPasswordDTO.NewPassword
            );

            CheckAndThrowIdentityErrors(result);
        }

        public async Task<GetUserDTO> CheckCredentials(CheckCredentialsDTO credentialsDTO)
        {
            IdentityUser user = await GetUserByCredentials(credentialsDTO.Email, credentialsDTO.Password);

            return new GetUserDTO() {
                Email = user.Email,
                Name = user.UserName,
                isAdmin = user.Email == adminEmail
            };
        }

        public async Task Create(CreateUserDTO userDTO)
        {
            if (await GetUserByEmail(userDTO.Email) != null)
            {
                throw new UserExistsException();
            }

            IdentityResult result = await _userManager.CreateAsync(
                new IdentityUser()
                {
                    UserName = userDTO.Name,
                    Email = userDTO.Email
                },
                userDTO.Password
            );

            CheckAndThrowIdentityErrors(result);
        }

        public async Task Delete(DeleteUserDTO userDTO)
        {
            IdentityUser user = await GetUserByEmail(userDTO.Email);

            if (user == null)
            {
                throw new NotFoundException();
            }

            IdentityResult result = await _userManager.DeleteAsync(user);

            CheckAndThrowIdentityErrors(result);
        }
    }
}