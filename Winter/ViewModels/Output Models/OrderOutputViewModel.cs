using Winter.Models;
using System;

namespace Winter.ViewModels.Output_Models
{
    public class OrderOutputViewModel
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DeliveryDate { get; set; }
        
        public Product Products { get; set; }
        public Category Category { get; set; }
    }
}
