using APi.Winter.DTO.Edit_Models;
using API.Winter.Controllers;
using API.Winter.DTO.Input_Models;
using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Winter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        readonly IBrand _brand;

        public BrandController(IBrand brand)
        {
            _brand = brand;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateBrand([FromBody] BrandIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _brand.AddBrand(model));
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
        [Route("{brandId}/")]
        public async Task<IActionResult> BrandById(int brandId)
        {
            try
            {
                if (brandId > 0)
                {
                    var data = await Task.Run(() => _brand.GetById(brandId));
                    return Ok(data);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound("The data requested for could not be found.");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                var result = await Task.Run(() => _brand.GetBrands());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("{brandId}")]
        public async Task<IActionResult> RemoveBrand(int brandId)
        {
            try
            {
                if (brandId > 0)
                {
                    var response = await Task.Run(() => _brand.DeleteBrand(brandId));
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
        public async Task<IActionResult> BrandCount()
        {
            try
            {
                var response = await Task.Run(() => _brand.CountBrand());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateCategory([FromBody] BrandEM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _brand.UpdateBrand(model));
                    if (response == true)
                    {
                        return Ok(true);
                    }
                    return BadRequest("Unable to Update!!");
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
    }
}
