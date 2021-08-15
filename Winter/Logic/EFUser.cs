﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Winter.Models;
using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Winter.Logic
{
    public class EFUser : IUsers
    {
        readonly WinterContext _context;
        readonly ModelFactory _modelFactory = new ModelFactory();
        public readonly UserManager<ApplicationUser> UserManager;
        public readonly SignInManager<ApplicationUser> SignInManager;
        private readonly IHttpContextAccessor _httpContext;

        public EFUser( IHttpContextAccessor httpContext,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, WinterContext context)
        {
            UserManager = userManager;
            _context = context;
            _httpContext = httpContext;

            //if (_httpContext.HttpContext.User.Claims.ToList().Find(r => r.Type == "id") != null)
            //{
            //    string userId = _httpContext.HttpContext.User.Claims.ToList().Find(r => r.Type == "id").Value;
            //    LoggedInUserId = Convert.ToInt64(userId);
            //}
        }

        public long CountUser()
        {
            try
            {
                var userCount = _context.UserProfile.ToList().Count();

                return userCount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<UserOM> GetUsers()
        {
            try
            {
                var data = _context.UserProfile.ToList();
                var users = data.Select(x => _modelFactory.Create(x));
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AddUser(UserIM model, out int UserId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = _modelFactory.Parse(model);
                    _context.UserProfile.Add(user);
                    int bit = _context.SaveChanges();
                    ts.Complete();

                    if (bit > 0)
                    {
                        UserId = bit;
                        return true;
                    }
                    else
                    {
                        UserId = 0;
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditUser(UserEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = _context.UserProfile.Find(model.Id);
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(model.PhoneNumber))
                            user.PhoneNumber = model.PhoneNumber;

                        if (!string.IsNullOrEmpty(model.FirstName))
                            user.FirstName = model.FirstName;

                        if (!string.IsNullOrEmpty(model.LastName))
                            user.LastName = model.LastName;

                        if (!string.IsNullOrEmpty(model.FirstName))
                            user.FirstName = model.FirstName;

                        int bit = _context.SaveChanges();
                        ts.Complete();

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUser(long UserId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = _context.UserProfile.Where(d => d.Id == UserId).FirstOrDefault();
                    if (user != null)
                    {
                        _context.UserProfile.Remove(user);
                        _context.SaveChanges();
                        ts.Complete();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserOM GetUserDetail(long UserId)
        {
            try
            {
                var data = _context.UserProfile.Find(UserId);
                var user = _modelFactory.Create(data);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public long GetUserId(string Email)
        {
            var userId = _context.UserProfile.Where(i => i.Email == Email).FirstOrDefault().Id;
            return userId;
        }

    }
}
