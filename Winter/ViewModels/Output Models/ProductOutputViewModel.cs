using Winter.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels.Output_Models
{
    public class ProductOutputViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductPath { get; set; }
        public string Ext { get; set; }
        public int UnitPrice { get; set; }

        //public float TotalPrice
        //{
        //    get
        //    {
        //       return Quantity * UnitPrice;
        //    }
        //}
        public float TotalPrice { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int? CategoryID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public virtual Category Category { get; set; }
        public List<IFormFile> Files { get; set; }

    }
}
