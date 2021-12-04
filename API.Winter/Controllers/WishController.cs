using API.Winter.DTO.Input_Models;
using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Winter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : BaseApiController
    {
        public readonly IWishList _wishList;

        public WishController(IWishList wishList)
        {
            _wishList = wishList;
        }

        [HttpPost]
        [Route("AddToWish")]
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
        [Route("{wishId}/WishDetail")]
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
        [Route("{UserId}/WishList")]
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
        [Route("{Id}/Delete/WishItem")]
        public async Task<IActionResult> RemoveItem(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var response = await Task.Run(() => _wishList.RemoveItem(Id));
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

        [HttpGet]
        [Route("{UserId}WishList/Count")]
        public async Task<IActionResult> UserWishListCount(long UserId)
        {
            try
            {
                if (UserId > 0)
                {
                    var response = await Task.Run(() => _wishList.GetUserWishListCount(UserId));
                    return Ok(response);
                }
                return NotFound("Not Found");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("{UserId}/Delete/WishItems")]
        public async Task<IActionResult> RemoveWishItems(long UserId)
        {
            try
            {
                if (UserId > 0)
                {
                    var response = await Task.Run(() => _wishList.RemoveWishListItems(UserId));
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