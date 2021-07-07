using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.Modelsss
{
    public class Product
    {
        public Product()
        {
            ProductFile = new HashSet<ProductFile>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        //public int? ProductFileId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<ProductFile> ProductFile { get; set; }
    }
}
