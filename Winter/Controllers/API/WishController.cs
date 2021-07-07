using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Winter.ILogic;
using Winter.Logic;
using Winter.ViewModels;
using Winter.ViewModels.Input_Models;

namespace Winter.Controllers
{
    [ApiController]
    [Route("api/Wish")]
    public class WishController : ControllerBase
    {
        public readonly IProduct _product;
        public readonly ICategory _category;
        public readonly IWishList _wishList;

        public WishController(IProduct product, ICategory category, IWishList wishList)
        {
            _product = product;
            _category = category;
            _wishList = wishList;
        }

        [HttpPost]
        [Route("/AddToWish")]
        public async Task<IActionResult> AddToWish([FromBody] WishIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _wishList.AddToWish(model));
                    if (response == true)
                    {
                        return Ok(true);
                    }
                    return BadRequest("Unable to add");
                }
                else
                {
                    return StatusCode(500, "error occurred");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpGet]
        //[Route("/wishId/")]
        //public async Task<IActionResult> WishDetail(int wishId)
        //{
        //    if (wishId > 0)
        //    {
        //        var wish = await Task.Run(() => _wishList.);
        //    }
        //    var productdetails = _product.GetProductById(Id);

        //    var generalView = new GeneralViewModel
        //    {
        //        ProductViewModel = productdetails,
        //    };

        //   // return View(generalView);
        //}

        [HttpGet]
        [Route("/UserId/WishList")]
        public async Task<IActionResult> UserWishLIst(int wishId)
        {
            try
            {
                if (wishId > 0)
                {
                    var wish = await Task.Run(() => _wishList.GetUserWishList(wishId));
                    return Ok(wish);
                }
                return NotFound("Not Found");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }
    }
}