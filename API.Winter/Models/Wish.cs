using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class Wish
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Product Product { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
