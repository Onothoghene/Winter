using System.Collections.Generic;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
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
    }
}
