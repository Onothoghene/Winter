using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class Cart
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateAdded { get; set; }

        public Product Product { get; set; }
        public UserProfile User { get; set; }
    }
}
