using System;
using System.Collections.Generic;

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
        public IEnumerable<SubCategoryOMLite> Category { get; set; }
    }
    
    public class CategoryTypeOMLite
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<BrandOMLite> Brands { get; set; }
        public IEnumerable<CategoryOMLite> Category { get; set; }
    }
}
