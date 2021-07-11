﻿using Winter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.ViewModels.Edit_Models
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public List<ProductFileInputViewModel> ProductFile { get; set; }
        public List<IFormFile> Files { get; set; }

        public virtual Category Category { get; set; }
        public SelectList Categories { get; set; }

    }

    public class ProductEM
    {
        public int ProductId { get; set; }
    }
}
