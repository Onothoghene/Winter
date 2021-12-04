using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
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
