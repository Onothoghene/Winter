using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
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
            if (ProductId > 0)
            {
                var data = _product.GetProductById(ProductId);
                var products = Mapper.Map<ProductOutputViewModel>(data);
                return View(products);
            }

            return RedirectToAction("Index", "Home");

        }

        #region Methods

        public long GetWishListCount(long UserId)
        {
            long wishlistCount = 0;
            HttpClient client = _helper.Initial();
            HttpResponseMessage response = client.GetAsync($"api/Wish/{UserId}WishList/Count").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringData = response.Content.ReadAsStringAsync().Result;
                wishlistCount = JsonConvert.DeserializeObject<long>(stringData);
            }
            return wishlistCount;
        }
        
        public long GetCartCount(long UserId)
        {
            long CartCount = 0;
            HttpClient client = _helper.Initial();
            HttpResponseMessage response = client.GetAsync($"api/Cart/{UserId}/CartCount").Result;
            if (response.IsSuccessStatusCode)
            {
                var stringData = response.Content.ReadAsStringAsync().Result;
                CartCount = JsonConvert.DeserializeObject<long>(stringData);
            }
            return CartCount;
        }

        #endregion

    }
}