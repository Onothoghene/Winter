using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;
using Winter.Models;

namespace Winter.Logic
{
    public interface IProduct
    {
        int AddProduct(Product model, List<ProductFileInputViewModel> productFiles);
        IEnumerable<ProductOM> GetRandomProducts();
        bool DeleteProduct(int Id);
        ProductOM GetProductById(int Id);
        IEnumerable<ProductOM> GetProducts();
        IEnumerable<ProductOM> GetNewArrivals();
        bool UpdateProduct(ProductEM model);
        void ConfigureInputViewModelForDropDown(ProductInputViewModel model);
        void ConfigureEditViewModelForDropDown(ProductEditViewModel model);
        long CountProduct();
    }
}
