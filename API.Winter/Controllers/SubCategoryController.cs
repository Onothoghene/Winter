using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Winter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseApiController
    {
        readonly ISubCategory _subcategory;

        public SubCategoryController(ISubCategory subcategory)
        {
            _subcategory = subcategory;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _subcategory.AddSubCategory(model));
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
        [Route("{subcategoryId}/")]
        public async Task<IActionResult> SubCategoryById(int subcategoryId)
        {
            try
            {
                if (subcategoryId > 0)
                {
                    var data = await Task.Run(() => _subcategory.GetSubCategoryById(subcategoryId));
                    return Ok(data);
                }
                else
                {
                    return NotFound("The info requested for could not be found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var result = await Task.Run(() => _subcategory.GetSubCategory());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("{subcategoryId}")]
        public async Task<IActionResult> RemoveSubCategory(int subcategoryId)
        {
            try
            {
                if (subcategoryId > 0)
                {
                    var response = await Task.Run(() => _subcategory.DeleteSubCategory(subcategoryId));
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
        public async Task<IActionResult> SubCategoryCount()
        {
            try
            {
                var response = await Task.Run(() => _subcategory.CountSubCategory());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateSubCategory([FromBody] SubCategoryEM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _subcategory.UpdateSubCategory(model));
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
