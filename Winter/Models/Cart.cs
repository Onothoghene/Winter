using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateModified { get; set; }

        public Product Product { get; set; }
        public UserProfile User { get; set; }
    }
}
