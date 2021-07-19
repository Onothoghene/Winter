using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Winter.Helpers;
using Winter.ILogic;
using Winter.Logic;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class HomeController : Controller
    {
        public readonly IProduct _product;
        public readonly ICategory _category;
        readonly HttpClientHelper _helper = new HttpClientHelper();

        public HomeController(IProduct product, ICategory category)
        {
            _product = product;
            _category = category;
        }

        public IActionResult Index()
        {   
            return View();
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

        public List<ProductOutputViewModel> GetNewArrivals()
        {
            var products = new List<ProductOutputViewModel>();
            HttpClient client = _helper.Initial();
            HttpResponseMessage response = client.GetAsync($"api/Products/NewArrivals").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringData = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductOutputViewModel>>(stringData);
            }
            return products;
        }
        
        public List<ProductOutputViewModel> GetRandomProducts()
        {
            var products = new List<ProductOutputViewModel>();
            HttpClient client = _helper.Initial();
            HttpResponseMessage response = client.GetAsync($"api/Products/RandomProducts").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringData = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductOutputViewModel>>(stringData);
            }
            return products;
        }

        #endregion

    }
}