using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Winter.Helpers;
using Winter.ViewModels;
using Winter.ViewModels.Output_Models;

namespace Winter.Controllers
{
    public class AccountController : BaseController
    {
        public readonly HttpClientLogic _httpClientLogic;
        HttpClientHelper _httpClientHelper = new HttpClientHelper();

        public AccountController()
        {
            _httpClientLogic = new HttpClientLogic();
        }

        [Route("user/index")]
        public async Task<IActionResult> Index(int Id)
        {
            if (Id == 0)
            {
                ViewBag.ErrorMessage = "User not Found";
                return RedirectToAction("Index", "Home");
            }
            var user = await GetUserById(Id);
            return View(user);
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string Urlendpoint = "api/Account/Register";
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = _httpClientHelper.Initial();
                    string stringData = JsonConvert.SerializeObject(model);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = await response.Content.ReadAsStringAsync();
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Error Occurred";
                    return View(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            string Urlendpoint = "api/Account/Login";
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = _httpClientHelper.Initial();
                    string stringData = JsonConvert.SerializeObject(model);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(Urlendpoint, contentData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string stringJWT = await response.Content.ReadAsStringAsync();
                        var jwt = JsonConvert.DeserializeObject<bool>(stringJWT);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<string>(stringJWT);
                        return View(model);
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    try
        //    {
        //        await SignInManager.SignOutAsync();
        //        HttpContext.Session.Remove(UserId);
        //        return RedirectToAction("Index", "home");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<IActionResult> EditProfile(string id)
        //{
        //    try
        //    {
        //        var user = await UserManager.FindByIdAsync(id);
        //        if (user == null)
        //        {
        //            ViewBag.ErrorMessage = "User not Found";
        //            return RedirectToAction("Index", "Account");
        //        }
        //        //var userClaims = await UserManager.GetClaimsAsync(user);
        //        //var userRoles = await UserManager.GetRolesAsync(user);

        //        var model = new EditUserViewModel
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            //Claims = userClaims.Select(c => c.Value).ToList(),
        //            //Roles = userRoles
        //        };
        //        return View(model);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditProfile(EditUserViewModel model)
        //{
        //    try
        //    {
        //        var user = await UserManager.FindByIdAsync(model.Id);
        //        if (user == null)
        //        {
        //            ViewBag.ErrorMessage = "User not Found";
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            user.Email = model.Email;
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            user.FullName = model.FirstName + " " + model.LastName;
        //            user.UserName = model.Email;

        //            var result = await UserManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Account", new { model.Id });
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
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                if (id > 0)
                {

                }
                ViewBag.ErrorMessage = "Invalid User";
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Route("user/change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await UserManager.GetUserAsync(User);

        //            if (user == null)
        //            {
        //                return RedirectToAction("Login", "Account");
        //            }
        //            var result = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        //            if (!result.Succeeded)
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError(string.Empty, error.Description);
        //                }
        //                return View();
        //            }
        //            await SignInManager.RefreshSignInAsync(user);
        //            return RedirectToAction("Index", "Account", new { user.Id });
        //        }
        //        return View(model);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #region Methods

        public async Task<UserViewModel> GetUserById(int Id)
        {
            string endpoint = $"api/User/{Id}";
            var response = await _httpClientLogic.GetById<UserViewModel>(endpoint);
            return response;
        }
        
        public async Task<bool> DeleteUserAccount(int Id)
        {
            string endpoint = $"api/User/{Id}";
            var response = await _httpClientLogic.GetById<bool>(endpoint);
            return response;
        }

        #endregion

    }
}