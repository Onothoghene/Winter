using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winter.Models;

namespace Winter.ViewModels.Input_Models
{
    public class ProductInputViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This field is required")]
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

        //public IEnumerable<SelectListItem> Categories
        //{
        //    get
        //    {
        //        JeanStationContext _context = new JeanStationContext();
        //        var ListOfCategories = new SelectList(_context.Category, "Id", "CategoryName");

        //        return ListOfCategories;
        //    }
        //}

        public SelectList Categories { get; set; }


    }
}
