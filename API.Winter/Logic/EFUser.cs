using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;
using Winter.API.Logic.Interfaces;
using Winter.API.Models;

namespace Winter.API.Logic
{
    public class EFUser : IUsers
    {
        readonly WinterContext _context;
        readonly IMapper _mapper;
        //private readonly IHttpContextAccessor _httpContext;

        public EFUser(WinterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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
                var users = _mapper.Map<IEnumerable<UserOM>>(data);
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
                    var user = _mapper.Map<UserProfile>(model);
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

        public UserOM GetUserDetail(int UserId)
        {
            try
            {
                var data = _context.UserProfile.Where(e => e.Id == UserId).FirstOrDefault();
                if (data != null)
                {
                    var user = _mapper.Map<UserOM>(data);
                    return user;
                }
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetUserId(string Email)
        {
            var userId = _context.UserProfile.Where(i => i.Email == Email).FirstOrDefault().Id;
            return userId;
        }

        public UserOM GetUserByEmail(string Email)
        {
            try
            {
                var data = _context.UserProfile.Where(i => i.Email == Email).FirstOrDefault();
                if (data != null)
                {
                    var user = _mapper.Map<UserOM>(data);
                    return user;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
