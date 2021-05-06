using System;
using System.Collections.Generic;
using BADoc.Entities.Models;
using BADoc.Entities.Enums;

namespace BADoc.UseCases.DTO
{
    public class GetTreeViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public NodeType Type { get; set; }
        public string Icon { get; set; }

        public Guid? ParentId { get; set; }
        public List<GetTreeViewDTO> Childs { get; set; }

        public static GetTreeViewDTO FromCategory(Category category) => new GetTreeViewDTO()
        {
            Id = category.Id,
            Name = category.Name,
            Type = NodeType.Category,
            ParentId = category.ParentCategoryId,
            Icon = category.Icon
        };

        public static GetTreeViewDTO FromPage(Page page) => new GetTreeViewDTO()
        {
            Id = page.Id,
            Name = page.Name,
            Type = NodeType.Page,
            ParentId = page.CategoryId,
            Icon = page.Icon
        };

       

    }
}