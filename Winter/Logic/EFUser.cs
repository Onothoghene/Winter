using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Winter.Models;
using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.Logic
{
    public class EFUser : IUsers
    {
        readonly WinterContext _context;
        readonly ModelFactory _modelFactory = new ModelFactory();

        public EFUser(WinterContext context)
        {
            _context = context;
        }

        //public readonly UserManager<ApplicationUser> UserManager;

        //public EFUser(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        //{
        //    UserManager = userManager;
        //}

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

        public bool AddUser(UserIM model)
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
                        return true;
                    else
                        return false;
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
                        //user
                    }
                    int bit = _context.SaveChanges();
                    ts.Complete();

                    if (bit > 0)
                        return true;
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

    }
}
