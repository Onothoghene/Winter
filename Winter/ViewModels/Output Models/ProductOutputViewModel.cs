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
        [Required(ErrorMessage = "This field is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        //public int? ProductFileId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int count { get; set; }
        public string  Category { get; set; }

        public List<ProductFileInputViewModel> ProductFile { get; set; }

    }
}
