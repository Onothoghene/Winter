using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Winter.API.DTO.Input_Models;
using Winter.API.Logic.Interfaces;

namespace Winter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : BaseApiController
    {
        public readonly ICartItem _cartItem;

        public CartController(ICartItem cartItem)
        {
            _cartItem = cartItem;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] CartIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _cartItem.AddToCart(model));
                    if (response == true)
                    {
                        return Ok(true);
                    }
                    return BadRequest("Unable to Add!!");
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
        [Route("{cartId}/CartDetail")]
        public async Task<IActionResult> CartDetail(long cartId)
        {
            try
            {
                if (cartId > 0)
                {
                    var wish = await Task.Run(() => _cartItem.GetCartDetails(cartId));
                    return Ok(wish);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound("The Cart Item requested for could not be found.");
            }
        }

        [HttpGet]
        [Route("{UserId}/CartList")]
        public async Task<IActionResult> UserCartList(long userId)
        {
            try
            {
                if (userId > 0)
                {
                    var wish = await Task.Run(() => _cartItem.GetUserCartList(userId));
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
        [Route("{Id}/Delete/CartItem")]
        public async Task<IActionResult> RemoveItem(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var response = await Task.Run(() => _cartItem.RemoveItem(Id));
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

        [HttpDelete]
        [Route("{UserId}/Delete/CartItems")]
        public async Task<IActionResult> RemoveUserItems(long UserId)
        {
            try
            {
                if (UserId > 0)
                {
                    var response = await Task.Run(() => _cartItem.RemoveUserItems(UserId));
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
        [Route("{UserId}/Count")]
        public async Task<IActionResult> UserCartCount(long UserId)
        {
            try
            {
                if (UserId > 0)
                {
                    var response = await Task.Run(() => _cartItem.GetUserCartItemCount(UserId));
                    return Ok(response);
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