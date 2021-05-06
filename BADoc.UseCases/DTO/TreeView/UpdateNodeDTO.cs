using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class UpdateNodeDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Icon { get; set; }

        public Guid? ParentId { get; set; } = null;

        public Category ToCategory() => new Category()
        {
            Id = this.Id,
            Name = this.Name,
            ParentCategoryId = this.ParentId,
            Icon = this.Icon
        };

        public Page ToPage() => new Page()
        {
            Id = this.Id,
            Name = this.Name,
            CategoryId = this.ParentId,
            Icon = this.Icon
        };

        public Page ToPage(Page originalPage)
        {
            originalPage.Id = this.Id;
            originalPage.Name = this.Name;
            originalPage.CategoryId = this.ParentId;
            originalPage.Icon = this.Icon;

            return originalPage;
        }

        public Category ToCategory(Category originalCategory)
        {
            originalCategory.Id = this.Id;
            originalCategory.Name = this.Name;
            originalCategory.ParentCategoryId = this.ParentId;
            originalCategory.Icon = this.Icon;

            return originalCategory;
        }

    }
}