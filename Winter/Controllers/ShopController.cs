using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Winter.Helpers;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class ShopController : Controller
    {
        public readonly IHttpClientLogic _httpClientLogic;
        //readonly HttpClientHelper _helper = new HttpClientHelper();

        public ShopController(IHttpClientLogic httpClientLogic)
        {
            _httpClientLogic = httpClientLogic;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

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

        //public async Task<ProductOutputViewModel> GetWishListCount(int UserId)
        //{
        //    string endpoint = $"api/Wish/{UserId}WishList/Count";
        //    var product = await _httpClientLogic.GetById<ProductOutputViewModel>(endpoint);
        //    return product;
        //}
        
        public async Task<int> GetWishListCount(int UserId)
        {
            string endpoint = $"api/Wish/{UserId}WishList/Count";
            int wishlistCount = await _httpClientLogic.GetById<int>(endpoint);
            return wishlistCount;
        }

        //public long GetWishListCount(long UserId)
        //{
        //    long wishlistCount = 0;
        //    HttpClient client = _helper.Initial();
        //    HttpResponseMessage response = client.GetAsync($"api/Wish/{UserId}WishList/Count").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringData = response.Content.ReadAsStringAsync().Result;
        //        wishlistCount = JsonConvert.DeserializeObject<long>(stringData);
        //    }
        //    return wishlistCount;
        //}

        public async Task<int> GetCartCount(int UserId)
        {
            string endpoint = $"api/Cart/{UserId}/CartCount";
            int CartCount = await _httpClientLogic.GetById<int>(endpoint);
            return CartCount;
        }

        //public long GetCartCount(long UserId)
        //{
        //    long CartCount = 0;
        //    HttpClient client = _helper.Initial();
        //    HttpResponseMessage response = client.GetAsync($"api/Cart/{UserId}/CartCount").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringData = response.Content.ReadAsStringAsync().Result;
        //        CartCount = JsonConvert.DeserializeObject<long>(stringData);
        //    }
        //    return CartCount;
        //}

        #endregion

    }
}