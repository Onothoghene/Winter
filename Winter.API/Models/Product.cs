using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class Product
    {
        public Product()
        {
            Files = new HashSet<Files>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int? BrandId { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<Files> Files { get; set; }
    }
}
