using System;

namespace Winter.API.DTO.Output_Models
{

    public class CategoryOM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

    }

    public class CategoryOMLite
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
