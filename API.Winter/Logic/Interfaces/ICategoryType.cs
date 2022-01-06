using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
{
    public interface ICategoryType
    {
        bool Add(CategoryTypeIM model);
        IEnumerable<CategoryTypeOM> GetList();
        CategoryTypeOM GetById(int Id);
        bool Delete(int Id);
        bool Update(CategoryTypeEM model);
        //int CountCategory(CategoryOutputViewModel model);
        long Count();
    }
}
