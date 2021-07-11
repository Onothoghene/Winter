using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class OrderRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalAmount { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public long AddedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateCancelled { get; set; }
        public DateTime? DateApproved { get; set; }

        public UserProfile AddedByNavigation { get; set; }
        public Product Product { get; set; }
    }
}
