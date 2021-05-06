using System;
using System.Collections.Generic;

namespace BADoc.Entities.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public IEnumerable<Page> Pages { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
