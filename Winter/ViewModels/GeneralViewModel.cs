using System.Collections.Generic;
using Winter.Models;
using Winter.ViewModels.Output_Models;

namespace Winter.ViewModels
{
    public class GeneralViewModel
    {
        public int CategoryCount { get; set; }
        public int UserCount { get; set; }
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }

        public ProductOutputViewModel ProductViewModel { get; set; }
        public UserViewModel User { get; set; }

        public IEnumerable<CategoryOutputViewModel> CategoryOutputViewModel { get; set; }
        public IEnumerable<ProductOutputViewModel> ProductOutputViewModel { get; set; }
        public IEnumerable<OrderOutputViewModel> OrderOutputViewModel { get; set; }

      //  public IEnumerable<ProductOutputViewModel> ProductOutputViewModel { get; set; }
    }
}
