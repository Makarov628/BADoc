using System;
using System.ComponentModel.DataAnnotations;

using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class UpdatePageDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        public Page ToPage() => new Page()
        {
            Id = this.Id,
            Content = this.Content
        };

        public Page ToPage(Page originalPage)
        {
            originalPage.Id = this.Id;
            originalPage.Content = this.Content;

            return originalPage;
        }

    }
}