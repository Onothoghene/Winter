using System;
using System.ComponentModel.DataAnnotations;

namespace Winter.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
     //   public ICollection<Product> Product { get; set; }
    }
}
