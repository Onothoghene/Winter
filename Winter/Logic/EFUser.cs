using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Winter.Logic
{
    public class EFUser : IUsers
    {

        public readonly UserManager<IdentityUser> UserManager;

        public EFUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
        }

        public int CountUser()
        {
            var count = UserManager.Users.Count();

            return count;
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            var resp = UserManager.Users;
           return resp;
        }
    }
}
