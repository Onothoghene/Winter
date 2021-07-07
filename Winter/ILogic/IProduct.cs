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
        //int AddProduct(ProductInputViewModel model);
        bool DeleteProduct(int? Id);
        ProductOutputViewModel GetProductById(int? Id);
        IEnumerable<ProductOutputViewModel> GetProducts();
        IEnumerable<ProductOutputViewModel> GetNewArrivals();
        bool UpdateProduct(ProductEditViewModel model);
        void ConfigureInputViewModelForDropDown(ProductInputViewModel model);
        void ConfigureEditViewModelForDropDown(ProductEditViewModel model);
        int CountProduct();
    }
}
