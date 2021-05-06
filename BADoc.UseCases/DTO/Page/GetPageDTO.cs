using System;
using System.ComponentModel.DataAnnotations;
using BADoc.Entities.Models;

namespace BADoc.UseCases.DTO
{
    public class GetPageDTO
    {
        [Required]
        public string Content { get; set; }


        public static GetPageDTO FromPage(Page page)
        {
            return new GetPageDTO() {
                Content = page.Content
            };
        }
    }


}