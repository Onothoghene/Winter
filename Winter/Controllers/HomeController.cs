using Microsoft.AspNetCore.Mvc;
using Winter.ILogic;
using Winter.Logic;
using Winter.ViewModels;

namespace Winter.Controllers
{
    public class HomeController : Controller
    {
        public readonly IProduct _product;
        public readonly ICategory _category;

        public HomeController(IProduct product, ICategory category)
        {
            _product = product;
            _category = category;
        }

        public IActionResult Index()
        {
            GeneralViewModel viewModel = new GeneralViewModel
            {
                ProductOutputViewModel = _product.GetNewArrivals(),
            };
            return View(viewModel);
        }

        //public IActionResult NewArrivals()
        //{
        //    GeneralViewModel viewModel = new GeneralViewModel
        //    {
        //        ProductOutputViewModel = _product.GetNewArrivals(),
        //    };

        //    return PartialView(viewModel);
        //}

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Items()
        {
            return View();
        }

        #region Methods

        #endregion

    }
}