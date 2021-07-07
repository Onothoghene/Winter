using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
            ProductFile = new HashSet<ProductFile>();
            Wish = new HashSet<Wish>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public Category Category { get; set; }
        public ICollection<Cart> Cart { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<ProductFile> ProductFile { get; set; }
        public ICollection<Wish> Wish { get; set; }
    }
}
