using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Winter.API.Data;
using Winter.API.DTO;
using Winter.API.Logic.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Winter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        readonly UserManager<ApplicationUser> UserManager;
        readonly SignInManager<ApplicationUser> SignInManager;
        readonly IAccount _account;

        public AccountController(IAccount account, UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
            _account = account;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _account.LoginUser(model));
                    if (response != null)
                    {
                        return Ok(true);
                    }
                    return BadRequest("Unable to Log in user!!");
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

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await Task.Run(() => _account.RegisterUser(model));
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

    }
}
