using System;
using System.Collections.Generic;

namespace API.Winter.DTO.Input_Models
{
    public class ProductIM
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public List<ProductFileIM> ProductFile { get; set; }
       
    }

    public class ProductFileIM
    {
        public int ProductFileId { get; set; }
        public string FileName { get; set; }
        public string FileUniqueName { get; set; }
        public string ProductUrl { get; set; }
        public string ProductUrlUniqueName { get; set; }
        public string Ext { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
