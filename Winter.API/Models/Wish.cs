using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class Wish
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateAdded { get; set; }

        public Product Product { get; set; }
        public UserProfile User { get; set; }
    }
}
