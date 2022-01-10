using System;

namespace API.Winter.DTO.Output_Models
{

    public class SubCategoryOM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }

    }

    public class SubCategoryOMLite
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
