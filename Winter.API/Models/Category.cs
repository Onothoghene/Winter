using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public ICollection<Product> Product { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
    }
}
