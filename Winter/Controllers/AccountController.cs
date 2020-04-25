using Winter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Winter.Models;

namespace JeanStation.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<ApplicationUser> UserManager;
        public readonly SignInManager<ApplicationUser> SignInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public async Task<IActionResult> Index(string Name)
        {
            var user = await UserManager.FindByNameAsync(Name);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not Found";
                return RedirectToAction("Index", "Home");
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.FullName,
            };
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.Name,
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                };
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                };
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMessage = "User not Found";
                return RedirectToAction("Index", "Account");
            }
            //var userClaims = await UserManager.GetClaimsAsync(user);
            //var userRoles = await UserManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.FullName,
                //Claims = userClaims.Select(c => c.Value).ToList(),
                //Roles = userRoles
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserViewModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User not Found";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                user.Email = model.Email;
                user.FullName = model.Name;
                user.UserName = model.Email;

                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                };
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>DeleteAccount(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = "User cannot be found";
                return View();
            }
            else{
                var result = await UserManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                      return RedirectToAction("Index", "Home");
                };
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("Index", "Home");
            }
          
         }

    }
}