using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
{
    public interface ICategory
    {
        bool AddCategory(CategoryIM model);
        IEnumerable<CategoryOM> GetCategory();
        IEnumerable<CategoryOMLite> GetCategoryLite();
        CategoryOM GetCategoryById(int Id);
        bool DeleteCategory(int Id);
        bool UpdateCategory(CategoryEM model);
        int CountCategory();
        FullCategoryOM GetFullCategoryList();
        //IEnumerable<FullCategoryOM> GetFullCategoryList();
        IEnumerable<CategoryOMLite2> GetCategoryLite2();
    }
}
