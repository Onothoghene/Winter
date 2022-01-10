﻿using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Winter.Controllers
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
                return NotFound("The Category requested for could not be found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "error occurred");
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
                //return StatusCode(500, ex);
                return StatusCode(500, "error occurred");
            }

        }

        [HttpDelete]
        [Route("{categoryId}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var response = await Task.Run(() => _category.DeleteCategory(categoryId));
                    if (response == true)
                    {
                        //return Ok(true);
                        return Ok("True");
                    }
                    else
                    {
                        return BadRequest("Unable to delete");
                    }
                }
                return BadRequest("Error Occurred");
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

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryEM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _category.UpdateCategory(model));
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

        [HttpGet]
        [Route("full")]
        public async Task<IActionResult> GetFullCategory()
        {
            try
            {
                var result = await Task.Run(() => _category.GetFullCategoryList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "error occurred");
            }

        }

        [HttpGet]
        [Route("lite")]
        public async Task<IActionResult> GetCategoriesLite()
        {
            try
            {
                var result = await Task.Run(() => _category.GetCategoryLite2());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "error occurred");
            }

        }
    }
}
