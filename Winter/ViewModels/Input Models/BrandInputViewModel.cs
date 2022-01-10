using System.Collections.Generic;
using Winter.ViewModels.Output_Models;

namespace Winter.ViewModels.Input_Models
{
    public class BrandInputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BrandOutputViewModel> Brand { get; set; }
    }
}
