using System.Collections.Generic;

namespace API.Winter.DTO.Output_Models
{
    public class OverViewOM
    {
        public int CategoryCount { get; set; }
        public int UserCount { get; set; }
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }

        //public ProductOM ProductViewModel { get; set; }
        //public UserOM User { get; set; }
        
        public List<UserOM> Users { get; set; }
        public List<CategoryOM> Categories { get; set; }
        public List<ProductOM> Products { get; set; }
        //public List<OrderOM> OrderOutputViewModel { get; set; }
    }
}
