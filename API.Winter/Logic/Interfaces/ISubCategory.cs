using System.Collections.Generic;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
{
    public interface ISubCategory
    {
        bool AddSubCategory(SubCategoryIM model);
        IEnumerable<SubCategoryOM> GetSubCategory();
        SubCategoryOM GetSubCategoryById(int Id);
        bool DeleteSubCategory(int Id);
        bool UpdateSubCategory(SubCategoryEM model);
        //int CountCategory(CategoryOutputViewModel model);
        long CountSubCategory();
    }
}
