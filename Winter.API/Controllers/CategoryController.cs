using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Winter.API.DTO.Input_Models;
using Winter.API.Logic.Interfaces;

namespace Winter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _category.AddCategory(model));
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
        [Route("{categoryId}/")]
        public async Task<IActionResult> CategoryById(int categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var wish = await Task.Run(() => _category.GetCategoryById(categoryId));
                    return Ok(wish);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound("The Category requested for could not be found.");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var result = await Task.Run(() => _category.GetCategory());
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpDelete]
        [Route("{categoryId}/Delete")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var response = await Task.Run(() => _category.DeleteCategory(categoryId));
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
        public async Task<IActionResult> CategoryCount()
        {
            try
            {
                var response = await Task.Run(() => _category.CountCategory());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }
    }
}
