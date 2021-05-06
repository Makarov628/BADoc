using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Enums;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class CreateNodeDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public NodeType Type { get; set; }

        public string Icon { get; set; }

        public Guid? ParentId { get; set; } = null;


        public Category ToCategory() => new Category()
        {
            Name = this.Name,
            ParentCategoryId = this.ParentId,
            Icon = this.Icon
        };

        public Page ToPage() => new Page()
        {
            Name = this.Name,
            CategoryId = this.ParentId,
            Icon = this.Icon
        };
    }
}