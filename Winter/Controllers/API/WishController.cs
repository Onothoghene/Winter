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
                    var response = await Task.Run(() => _wishList.AddToWishLIst(model));
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

        [HttpGet]
        [Route("/wishId/Detail")]
        public async Task<IActionResult> WishDetail(long wishId)
        {
            try
            {
                var wish = await Task.Run(() => _wishList.GetWishDetail(wishId));
                return Ok(wish);
            }
            catch (Exception)
            {
                return NotFound("The Wish requested for could not be found.");
            }
        }

        [HttpGet]
        [Route("/UserId/WishList")]
        public async Task<IActionResult> UserWishLIst(long userId)
        {
            try
            {
                if (userId > 0)
                {
                    var wish = await Task.Run(() => _wishList.GetUserWishList(userId));
                    return Ok(wish);
                }
                return NotFound("Not Found");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("/Id/Delete")]
        public async Task<IActionResult> RemoveItem(long wishId)
        {
            try
            {
                if (wishId > 0)
                {
                    var response = await Task.Run(() => _wishList.RemoveItem(wishId));
                    if (response == true)
                    {
                        return Ok(response);
                    }
                    return BadRequest(false);
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