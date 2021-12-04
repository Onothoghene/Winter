using API.Winter.Data;
using API.Winter.DTO;
using API.Winter.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Winter.Controllers
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("{email}/logout")]
        public async Task<IActionResult> Logout(string email)
        {
            try
            {
                var response =await  _account.Logout(email);
                if (response == true)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error Occurred!");
            }
        }

        [Route("change-password")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _account.ChangePassword(model);
                    return Ok(response);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: Unable to change User Password!");
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("forgot-password")]
        //public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.FindByEmailAsync(model.Email);
        //            if (user != null)
        //            {
        //                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //                //var resetUrl = new Uri(Url.Link(_appConfig.ApplicationUrl.ForgetPasswordUrl, new { token, email = user.Email }));
        //                //var routeUrl = Url.RouteUrl(_appConfig.ApplicationUrl.ForgetPasswordUrl, new { token, email = user.Email });
        //                //var resulter = Url.Link(_appConfig.ApplicationUrl.ForgetPasswordUrl, new { token, email = user.Email });

        //                token = System.Web.HttpUtility.UrlEncode(token);
        //                var callback = _appConfig.ApplicationUrl.ForgetPasswordUrl + "?token=" + token + "&email=" + user.Email;

        //                var userDetails = _userService.GetUserDetails(user.Id);

        //                await _appConfig.SendEmailAsync(user.Email, null, null, EmailFormatter.ResetPassword(userDetails.FirstName, callback/*resetUrl.OriginalString*/));
        //                await _appConfig.SendEmailTrapAsync(user.Email, null, EmailFormatter.ResetPassword(userDetails.FirstName, callback/*resetUrl.OriginalString*/));

        //                return Ok(true);
        //            }
        //            else
        //            {
        //                return NotFound("User Not Found!");
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest(ModelState);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _proLogger.Error(ex);
        //        return StatusCode(500, "Error: Unable to Generate Password Reset Token and Send Email!");
        //    }
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("reset-password")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        //{
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.FindByEmailAsync(model.Email);

        //            if (user != null)
        //            {
        //                // var data = System.Web.HttpUtility.UrlDecode(model.Token);
        //                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        //                if (!result.Succeeded)
        //                {
        //                    foreach (var error in result.Errors)
        //                    {
        //                        ModelState.AddModelError("", error.Description);
        //                    }
        //                    return BadRequest(ModelState);
        //                }
        //                else
        //                {
        //                    await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);

        //                    var firmUserId = _userService.GetFirmUserIdByAspId(user.Id);
        //                    var userId = _userService.GetUserProfileId(user.Id);

        //                    FirmActivityLogModel log = new FirmActivityLogModel
        //                    {
        //                        ActionTypeId = (int)ActionTypeEnum.Edit,
        //                        ActivityTypeId = (int)PermissionEntityEnum.Resetpassword,
        //                        CreatedBy = firmUserId,
        //                        Description = "reset password",
        //                        // MatterId = model.MatterId,
        //                        ResourceId = userId
        //                    };

        //                    SaveLog(log);

        //                    return Ok(true);
        //                }
        //            }
        //            else
        //            {
        //                return NotFound("User Not Found!");
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest(ModelState);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _proLogger.Error(ex);
        //        return StatusCode(500, "Error Resetting User Password!");
        //    }
        //}


    }
}
