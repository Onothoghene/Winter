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

        //public int CategoryCount { get; set; }
    }
    
    public class SubCategoryOutputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public int CategoryCount { get; set; }
    }

}
