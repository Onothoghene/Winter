using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Files = new HashSet<Files>();
            OrderRequest = new HashSet<OrderRequest>();
            Wish = new HashSet<Wish>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? BrandId { get; set; }
        public int? SubCategoryId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
        public virtual ICollection<Wish> Wish { get; set; }
    }
}
