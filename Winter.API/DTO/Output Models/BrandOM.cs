using System;

namespace Winter.API.DTO.Output_Models
{

    public class BrandOM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

    }

    public class BrandOMLite
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
