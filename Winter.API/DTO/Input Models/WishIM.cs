using System;

namespace Winter.API.DTO.Input_Models
{
    public class WishIM
    {
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
