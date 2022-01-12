using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels.Input_Models
{
    public class ProductInputViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public List<ProductFileInputViewModel> ProductFile { get; set; }
        public List<IFormFile> Files { get; set; }
       
        public SelectList SubCategories { get; set; }


    }

    public class ProductIM
    {

    }
}
