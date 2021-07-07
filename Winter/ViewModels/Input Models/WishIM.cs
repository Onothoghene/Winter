using Winter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.ViewModels.Input_Models
{
    public class WishIM
    {
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
