using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Winter.ViewModels.Input_Models
{
    public class ProductFileInputViewModel
    {
        public int ProductFileId { get; set; }
        public string FileName { get; set; }
        public string FileUniqueName { get; set; }
        public string ProductUrl { get; set; }
        public string ProductUrlUniqueName { get; set; }
        public string Ext { get; set; }
        public DateTime? DateAdded { get; set; }
        //public List<IFormFile> Files { get; set; }
    }
}
