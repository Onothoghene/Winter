using System.Collections.Generic;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
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
