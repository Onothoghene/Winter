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

        public async Task<IActionResult> Index(string Id)
        {
            var user = await UserManager.FindByIdAsync(Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not Found";
                return RedirectToAction("Index", "Home");
            }

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                LastName = user.LastName,
                FirstName = user.FirstName,
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
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FirstName + " " + model.LastName,
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
                FirstName = user.FirstName,
                LastName = user.LastName,
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
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.FullName = model.FirstName +" "+model.LastName;
                user.UserName = model.Email;

                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Account" ,new { model.Id });
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

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword( ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                var result = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await SignInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index","Account" , new { user.Id });
            }
            return View(model);
        }

    }
}