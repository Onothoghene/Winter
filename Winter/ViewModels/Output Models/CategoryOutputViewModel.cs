using Winter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels.Output_Models
{
    public class CategoryOutputViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<Product> Product { get; set; }

        public int count { get; set; }
    }
}
