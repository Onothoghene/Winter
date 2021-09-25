using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Winter.API.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Winter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        readonly UserManager<ApplicationUser> UserManager;
        readonly SignInManager<ApplicationUser> SignInManager;

        public AccountController(UserManager<ApplicationUser> _UserManager, SignInManager<ApplicationUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }



    }
}
