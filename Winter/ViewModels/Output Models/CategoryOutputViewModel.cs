using System.Collections.Generic;

namespace Winter.ViewModels.Output_Models
{
    public class CategoryOutputViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public int CategoryCount { get; set; }
    }
    
    public class CategoryTypeOutputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubCategoryOutputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategoryTypeOVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryOVM> Category { get; set; }
    }

    public class CategoryOVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SubCategoryOVM> SubCategory { get; set; }
    }

    public class SubCategoryOVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FullCategoryOutputViewModel
    {
        public IEnumerable<CategoryTypeOVM> CategoryType { get; set; }
        public IEnumerable<BrandOutputViewModel> Brands { get; set; }
    }

}
