using System;

namespace Winter.ViewModels.Output_Models
{
    public class OrderOutputViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public int UnitPrice { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        
        //public Product Products { get; set; }
        //public Category Category { get; set; }
    }
}
