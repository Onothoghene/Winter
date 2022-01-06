using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Category = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
