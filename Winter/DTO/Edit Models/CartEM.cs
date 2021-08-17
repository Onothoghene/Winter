using System;

namespace Winter.DTO.Edit_Models
{
    public class CartEM
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public int Quantity { get; set; }
        //public DateTime DateModified { get; set; }
    }
}
