using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Category Category { get; set; }
    }
}
