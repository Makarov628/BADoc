using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Enums;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class UpdateUserPasswordDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

    }
}