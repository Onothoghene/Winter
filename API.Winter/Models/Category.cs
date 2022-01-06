using System;
using System.Collections.Generic;

namespace API.Winter.Models
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
        public int? CategoryTypeId { get; set; }

        public virtual CategoryType CategoryType { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
