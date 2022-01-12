using System.Collections.Generic;

namespace API.Winter.DTO.Output_Models
{
    public class CategoryTypeOM
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class CategoryTypeOMLite
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CategoryOMLite> Category { get; set; }
    }
}
