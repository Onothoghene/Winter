using Winter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Winter.Models;
using System;
using Winter.Logic;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Edit_Models;
using Microsoft.AspNetCore.Http;

namespace Winter.Controllers
{
    public class AccountController : BaseController
    {
        public readonly UserManager<ApplicationUser> UserManager;
        public readonly SignInManager<ApplicationUser> SignInManager;
        readonly IUsers _users;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUsers users)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _users = users;
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
                //FullName = user.FullName,
                LastName = user.LastName,
                FirstName = user.FirstName,
            };
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = new ApplicationUser
        //            {
        //                UserName = model.Email,
        //                Email = model.Email,
        //                FirstName = model.FirstName,
        //                LastName = model.LastName,
        //                FullName = model.FirstName + " " + model.LastName,
        //            };
        //            var result = await UserManager.CreateAsync(user, model.Password);
        //            if (result.Succeeded)
        //            {
        //                var newuser = new UserIM
        //                {

        //                };
        //                await SignInManager.SignInAsync(user, isPersistent: false);
        //                return RedirectToAction("Index", "Home");
        //            };
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //        }
        //        return View(model);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> RegisterOrUpdateUser(RegisterViewModel model)
        {
            try
            {
                if (model.UserId > 0)
                {
                    var user = await UserManager.FindByIdAsync(model.Id);
                    if (user == null)
                    {
                        ViewBag.ErrorMessage = "User not Found";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        //user.FullName = model.FirstName + " " + model.LastName;

                        var result = await UserManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            var userdetail = new UserEM
                            {
                                Id = model.UserId,
                                LastName = model.LastName,
                                FirstName = model.FirstName,
                                PhoneNumber = model.PhoneNumber,
                            };
                            var response = _users.EditUser(userdetail);
                            if (response != true)
                            {
                                return View("EditProfile", model);
                            }
                            else
                            {
                                return View("Index");
                            }
                        };
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                    return View("EditProfile", model);
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        int newUserId;
                        var user = new ApplicationUser
                        {
                            UserName = model.Email,
                            Email = model.Email,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            //FullName = model.FirstName + " " + model.LastName,
                        };
                        var result = await UserManager.CreateAsync(user, model.Password);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                            return View("Register", model);
                        }

                        var newuser = new UserIM
                        {
                            AspNetId = user.Id,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                        };

                        if (_users.AddUser(newuser, out newUserId) == true)
                        {
                            await SignInManager.SignInAsync(user, isPersistent: false);
                            HttpContext.Session.SetInt32(UserId, newUserId);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("Register");
                        }
                    }
                    return View("Register", model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByNameAsync(model.Email);
                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "User not found");
                        return View() ;
                    }
                    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var userId = _users.GetUserId(model.Email);
                        HttpContext.Session.SetInt32(UserId, (int)userId);
                        return RedirectToAction("Index", "Home");
                    };
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await SignInManager.SignOutAsync();
                HttpContext.Session.Remove(UserId);
                return RedirectToAction("Index", "home");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
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
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserViewModel model)
        {
            try
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
                    user.FullName = model.FirstName + " " + model.LastName;
                    user.UserName = model.Email;

                    var result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account", new { model.Id });
                    };
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);

                if (user == null)
                {
                    ViewBag.ErrorMessage = "User cannot be found";
                    return View();
                }
                else
                {
                    
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
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
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
                    return RedirectToAction("Index", "Account", new { user.Id });
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}