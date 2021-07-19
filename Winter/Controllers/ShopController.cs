using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Winter.Helpers;
using Winter.ILogic;
using Winter.Logic;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class ShopController : Controller
    {
        public readonly IProduct _product;
        public readonly ICategory _category;
        readonly HttpClientHelper _helper = new HttpClientHelper();

        public ShopController(IProduct product, ICategory category)
        {
            _product = product;
            _category = category;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult ProductDetails(int ProductId)
        {
            //if (Id == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //var productdetails = _product.GetProductById(Id);

            //var generalView = new GeneralViewModel
            //{
            //    ProductViewModel = productdetails,
            //};

            //return View(generalView);

            return View();
        }

        public List<ProductOutputViewModel> GetNotifications()
        {
            var products = new List<ProductOutputViewModel>();
            HttpClient client = _helper.Initial();
            HttpResponseMessage response = client.GetAsync($"api/v1/Notification").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringData = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductOutputViewModel>>(stringData);
            }
            return products;
        }

    }
}