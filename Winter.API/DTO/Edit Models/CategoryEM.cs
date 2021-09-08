using System;
using System.ComponentModel.DataAnnotations;

namespace Winter.API.DTO.Edit_Models
{
    public class CategoryEM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
