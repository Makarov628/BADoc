using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class DeleteNodeDTO
    {
        [Required]
        public Guid Id { get; set; }

        public Category ToCategory() => new Category()
        {
            Id = this.Id
        };

        public Page ToPage() => new Page()
        {
            Id = this.Id
        };

        public Page ToPage(Page originalPage)
        {
            originalPage.Id = this.Id;
            return originalPage;
        }

        public Category ToCategory(Category originalCategory)
        {
            originalCategory.Id = this.Id;
            return originalCategory;
        }
        
    }
}