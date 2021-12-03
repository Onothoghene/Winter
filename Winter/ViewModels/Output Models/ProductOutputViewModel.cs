using System;
using System.Collections.Generic;
using Winter.ViewModels.Input_Models;

namespace Winter.ViewModels.Output_Models
{
    public class ProductOutputViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        //public int? ProductFileId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        //public int count { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }

        public List<ProductFileOutputViewModel> ProductFile { get; set; }

    }

}
