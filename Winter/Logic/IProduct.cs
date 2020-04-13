using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;

namespace Winter.Logic
{
    public interface IProduct
    {
        int AddProduct(ProductInputViewModel model);
        bool DeleteProduct(int? Id);
        ProductOutputViewModel GetProductById(int? Id);
        IEnumerable<ProductOutputViewModel> GetProducts();
        bool UpdateProduct(ProductEditViewModel model);
        //void ConfigureInputViewModelForDropDown(ProductInputViewModel model);
        //void ConfigureEditViewModelForDropDown(ProductInputViewModel model);
        int CountProduct();
    }
}
