using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
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
