using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAdded { get; set; }

        public Category Category { get; set; }
    }
}
