using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Enums;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class DeleteUserDTO
    {
        [Required]
        public string Email { get; set; }
    }
}