using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Enums;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not equals")]
        public string PasswordConfirm { get; set; }

    }
}