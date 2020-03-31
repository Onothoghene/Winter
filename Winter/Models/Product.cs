using System;
using System.ComponentModel.DataAnnotations;

namespace Winter.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FileUniqueName { get; set; }
        public string Url { get; set; }
        public string UrlUniqueName { get; set; }
        public string Ext { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual Category Category { get; set; }
       
    }
}
