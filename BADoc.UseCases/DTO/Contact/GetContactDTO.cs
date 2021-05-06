using System;

using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class GetContactDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }


        public static GetContactDTO FromContact(Contact contact) => new GetContactDTO()
        {
            Id = contact.Id,
            Name = contact.Name,
            Phone = contact.Phone,
            Email = contact.Email,
            Department = contact.Department
        };
    }
}
