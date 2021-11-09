using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Transactions;
using Winter.API.Data;
using Winter.API.DTO;
using Winter.API.DTO.Output_Models;
using Winter.API.Logic.Interfaces;
using Winter.API.Models;

namespace Winter.API.Logic
{
    public class EFAccount : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly WinterContext _context;
        readonly IMapper _mapper;
        readonly IUsers _users;

        public EFAccount(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, WinterContext context, IMapper mapper, IUsers users)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
            _users = users;
        }

        public async Task<bool> RegisterUser(RegistrationModel model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                    };
                    //var 
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var userProfile = new UserProfile
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AspNetId = user.Id,
                            DateAdded = DateTime.Now,
                        };
                        await _context.UserProfile.AddAsync(userProfile);

                        int bit = _context.SaveChanges();
                        ts.Complete();

                        if (bit > 0)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        await _userManager.DeleteAsync(user);
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserOM> LoginUser(LoginModel model)
        {
            try
            {
                UserOM response = new UserOM();
                var user = Task.Run(() =>_userManager.FindByEmailAsync(model.Email));
                if (user == null)
                    return null;
                    
                var result =  await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var userdetails = _users.GetUserByEmail(model.Email);
                    response =  _mapper.Map<UserOM>(userdetails);
                     return response;
                }
                else
                {
                    return new UserOM();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<bool> ResetPassword()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<string> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var resp = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);

                    if (resp == false)
                    {
                        return "Invalid current password!";
                    }
                    var res = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    return "Successful";
                }
                else
                {
                    return "User Not Found";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<bool> ForgotPassword()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<bool> Logout()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
