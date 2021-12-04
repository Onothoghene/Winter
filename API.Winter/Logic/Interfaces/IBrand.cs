using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
{
    public interface IBrand
    {
        bool AddBrand(BrandIM model);
        IEnumerable<BrandOM> GetBrands();
        BrandOM GetById(int Id);
        bool DeleteBrand(int Id);
        bool UpdateBrand(BrandEM model);
        long CountBrand();
    }
}
