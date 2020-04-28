using Microsoft.AspNetCore.Mvc;
using Winter.Logic;
using Winter.ViewModels;

namespace Winter.Controllers
{
    public class ShopController : Controller
    {
        public readonly IProduct _product;
        public readonly ICategory _category;

        public ShopController(IProduct product, ICategory category)
        {
            _product = product;
            _category = category;
        }

        public IActionResult Category()
        {
            //GeneralViewModel viewModel = new GeneralViewModel
            //{
            //    CategoryOutputViewModel = _category.GetCategory(),
            //    ProductOutputViewModel = _product.GetProducts(),
            //};
            //return View(viewModel);
            return View();
        }

        public IActionResult ProductDetails(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var productdetails = _product.GetProductById(Id);

            var generalView = new GeneralViewModel
            {
                ProductViewModel = productdetails,
            };

            return View(generalView);
        }
    }
}