using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Winter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseApiController
    {
        public readonly IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpGet]
        [Route("overview")]
        public async Task<IActionResult> OverView()
        {
            try
            {
                var data = await Task.Run(() => _admin.OverView());
                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound("Error Occured.");
            }
        }

    }
}