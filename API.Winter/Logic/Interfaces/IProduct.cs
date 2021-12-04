using System.Collections.Generic;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
{
    public interface IProduct
    {
        IEnumerable<ProductOM> GetRandomProducts();
        bool DeleteProduct(int Id);
        ProductOM GetProductById(int Id);
        IEnumerable<ProductOM> GetProducts();
        IEnumerable<ProductOM> GetNewArrivals();
        bool UpdateProduct(ProductEM model);
        //void ConfigureInputViewModelForDropDown(ProductInputViewModel model);
        //void ConfigureEditViewModelForDropDown(ProductEditViewModel model);
        int CountProduct();
        bool AddProduct(ProductIM model);
    }
}
