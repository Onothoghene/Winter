using Winter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.DTO.Output_Models
{
    public class WishOM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
