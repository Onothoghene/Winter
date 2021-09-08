namespace Winter.API.DTO.Edit_Models
{

    public class ProductEM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
