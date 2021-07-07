using System;

namespace Winter.ViewModels.Input_Models
{
    public class OrderInputViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DeliveryDate { get; set; }

        //public Product Products { get; set; }
        //public Category Category { get; set; }
    }
}
