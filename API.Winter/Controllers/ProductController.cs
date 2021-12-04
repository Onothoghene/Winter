using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Winter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        public readonly IProduct _products;

        public ProductController(IProduct product)
        {
            _products = product;
        }

        [HttpGet]
        [Route("RandomProducts")]
        public async Task<IActionResult> RandomProducts()
        {
            try
            {
                var products = await Task.Run(() => _products.GetRandomProducts());
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpGet]
        [Route("NewArrivals")]
        public async Task<IActionResult> NewArrivals()
        {
            try
            {
                var products = await Task.Run(() => _products.GetNewArrivals());
                return Ok(products);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("ProductId/Delete")]
        public async Task<IActionResult> RemoveProduct(int ProductId)
        {
            try
            {
                if (ProductId > 0)
                {
                    var response = await Task.Run(() => _products.DeleteProduct(ProductId));
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
        [Route("Count")]
        public async Task<IActionResult> UserCartCount()
        {
            try
            {
                var response = await Task.Run(() => _products.CountProduct());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

    }
}