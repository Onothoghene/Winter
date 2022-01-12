using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Winter.Helpers;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class ShopController : Controller
    {
        public readonly HttpClientLogic _httpClientLogic;
        HttpClientHelper _httpClientHelper = new HttpClientHelper();

        public ShopController()
        {
            _httpClientLogic = new HttpClientLogic();
        }

        [Route("category")]
        public async Task<IActionResult> Category()
        {
            var viewModel = await GetCategoryList();
            return View(viewModel);
        }

        [Route("cart")]
        public IActionResult ShoppingCart()
        {
            return View();
        }

        [Route("product/details")]
        public IActionResult ProductDetails(int ProductId)
        {
            if (ProductId > 0)
            {
                //    var data = _product.GetProductById(ProductId);
                //    var products = Mapper.Map<ProductOutputViewModel>(data);
                //    return View(products);
            }

            return RedirectToAction("Index", "Home");

        }

        #region Methods

        public async Task<int> GetWishListCount(int UserId)
        {
            string endpoint = $"api/Wish/{UserId}WishList/Count";
            int wishlistCount = await _httpClientLogic.GetById<int>(endpoint);
            return wishlistCount;
        }

        public async Task<int> GetCartCount(int UserId)
        {
            string endpoint = $"api/Cart/{UserId}/CartCount";
            int CartCount = await _httpClientLogic.GetById<int>(endpoint);
            return CartCount;
        }

        public async Task<FullCategoryOutputViewModel> GetCategoryList()
        {
            string endpoint = $"api/Category/full";
            var response = await _httpClientLogic.GetById<FullCategoryOutputViewModel>(endpoint);
            return response;
        }

        #endregion

    }
}