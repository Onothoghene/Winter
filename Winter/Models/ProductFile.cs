using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winter.Models
{
    public class ProductFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUniqueName { get; set; }
        public string ProductUrl { get; set; }
        public string ProductUrlUniqueName { get; set; }
        public string Ext { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateAdded { get; set; }
        public Product Product { get; set; }
    }
}
