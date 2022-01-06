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
    public class CategoryTypeController : BaseApiController
    {
        readonly ICategoryType _categoryType;

        public CategoryTypeController(ICategoryType categoryType)
        {
            _categoryType = categoryType;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CategoryTypeIM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _categoryType.Add(model));
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
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var response = await Task.Run(() => _categoryType.GetById(Id));
                    return Ok(response);
                }
                return NotFound("The Info requested for could not be found.");
            }
            catch (Exception)
            {
                return StatusCode(500, "error occurred");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCategoryTypes()
        {
            try
            {
                var result = await Task.Run(() => _categoryType.GetList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                //return StatusCode(500, ex);
                return StatusCode(500, "error occurred");
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> RemoveCategory(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var response = await Task.Run(() => _categoryType.Delete(Id));
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
        public async Task<IActionResult> Count()
        {
            try
            {
                var response = await Task.Run(() => _categoryType.Count());
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] CategoryTypeEM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _categoryType.Update(model));
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
