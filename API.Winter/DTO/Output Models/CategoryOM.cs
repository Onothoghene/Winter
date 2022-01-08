using System;

namespace API.Winter.DTO.Output_Models
{

    public class CategoryOM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

    }

    public class CategoryOMLite
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
