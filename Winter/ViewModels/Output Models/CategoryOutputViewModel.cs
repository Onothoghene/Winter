using System;

namespace Winter.ViewModels.Output_Models
{
    public class CategoryOutputViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        //public ICollection<Product> Product { get; set; }

        public int CategoryCount { get; set; }
    }

    public class CategoryOM
    {

    }

    public class CategoryOMLite
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
