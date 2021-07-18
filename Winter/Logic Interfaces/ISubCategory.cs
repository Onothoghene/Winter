using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;

namespace Winter.ILogic
{
    public interface ISubCategory
    {
        bool AddSubCategory(CategoryInputViewModel model);
        IEnumerable<CategoryOutputViewModel> GetSubCategory();
        CategoryOutputViewModel GetSubCategoryById(int Id);
        bool DeleteSubCategory(int Id);
        bool UpdateSubCategory(CategoryEditViewModel model);
        //int CountCategory(CategoryOutputViewModel model);
        long CountSubCategory();
    }
}
