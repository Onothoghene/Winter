using System.Collections.Generic;
using Winter.ViewModels.Output_Models;

namespace Winter.ViewModels.Input_Models
{
    public class CategoryInputViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryOutputViewModel> Category { get; set; }
        //public ICollection<Product> Product { get; set; }
    }
    
    public class CategoryTypeInputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryTypeOutputViewModel> CategoryType { get; set; }
    }
    
    public class SubCategoryInputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SubCategoryOutputViewModel> SubCategory { get; set; }
    }
}
