using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class Category
    {
        public Category()
        {
            Order = new HashSet<Order>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public ICollection<Order> Order { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
