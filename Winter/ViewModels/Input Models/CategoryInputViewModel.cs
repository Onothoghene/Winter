using Winter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels.Input_Models
{
    public class CategoryInputViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
