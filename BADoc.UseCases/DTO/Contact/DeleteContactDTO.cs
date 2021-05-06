using System;
using System.ComponentModel.DataAnnotations;

using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class DeleteContactDTO
    {
        [Required]
        public Guid Id { get; set; }

        public Contact ToContact() => new Contact()
        {
            Id = this.Id
        };
    }
}
