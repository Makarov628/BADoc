using System;
using System.ComponentModel.DataAnnotations;

using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class CreateContactDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Email { get; set; }

        public Contact ToContact() => new Contact() 
        {
            Name = this.Name,
            Phone = this.Phone,
            Email = this.Email,
            Department = this.Department
        };
    }
}
