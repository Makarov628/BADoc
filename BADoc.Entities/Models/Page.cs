using System;

namespace BADoc.Entities.Models
{
    public class Page
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }

        public Guid? CategoryId { get; set; } = null;
        public Category Category { get; set; }
    }
}
