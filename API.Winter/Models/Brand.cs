using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
