using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Enums;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class CheckCredentialsDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}