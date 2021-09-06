using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class OrderRequest
    {
        public int Id { get; set; }
        public int AddedBy { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? DateApproved { get; set; }
        public bool? IsCancelled { get; set; }
        public DateTime? DateCancelled { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Quantity { get; set; }

        public UserProfile AddedByNavigation { get; set; }
        public Product Product { get; set; }
    }
}
