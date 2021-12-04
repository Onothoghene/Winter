using System;
using System.Collections.Generic;

namespace API.Winter.DTO.Output_Models
{
    public class ProductOM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        //public int? ProductFileId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        //public int count { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }

        public List<ProductFileOM> ProductFile { get; set; }

    }

    public class ProductFileOM
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
