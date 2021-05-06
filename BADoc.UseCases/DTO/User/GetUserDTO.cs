using System;
using System.ComponentModel.DataAnnotations;

namespace BADoc.UseCases.DTO
{
    public class GetUserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; } = false;

    }
}