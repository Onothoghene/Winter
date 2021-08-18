using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Winter.Logic;
using Winter.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Winter.Controllers
{
    public class BaseController : Controller
    {
        public readonly UserManager<ApplicationUser> UserManager;
        public readonly SignInManager<ApplicationUser> SignInManager;
        readonly IUsers _users;

        public BaseController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUsers users)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _users = users;

            //bool isAuthenticated = User.Identity.IsAuthenticated;
            
        }

        
        public async void SetUserIdCookie()
        {
            bool IsSignedIn = SignInManager.IsSignedIn(User);

            if (IsSignedIn)
            {
                var user = await Task.Run(() => UserManager.GetUserAsync(User));
                var loggedInUser = _users.GetUserId(user.Email);
                 HttpContext.Session.SetInt32(UserId, (int)loggedInUser);
            }

        }
        public string UserId { get; set; } = "UserId";
    }
}
