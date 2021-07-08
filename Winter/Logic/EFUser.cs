using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using Winter.Models;

namespace Winter.Logic
{
    public class EFUser : IUsers
    {

        //public readonly UserManager<ApplicationUser> UserManager;

        //public EFUser(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        //{
        //    UserManager = userManager;
        //}

        //public int CountUser()
        //{
        //    var count = UserManager.Users.Count();

        //    return count;
        //}

        //public IEnumerable<ApplicationUser> GetUsers()
        //{
        //    var resp = UserManager.Users;
        //   return resp;
        //}
    }
}
