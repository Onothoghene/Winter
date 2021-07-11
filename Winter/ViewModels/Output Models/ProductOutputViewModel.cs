using Winter.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int count { get; set; }
        public string  Category { get; set; }

        public List<ProductFileInputViewModel> ProductFile { get; set; }

    }

    public class ProductOM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        //public int? ProductFileId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int count { get; set; }
        public string Category { get; set; }

        public List<ProductFileInputViewModel> ProductFile { get; set; }

    }
}
