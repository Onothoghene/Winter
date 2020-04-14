using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Winter.Logic
{
    public interface IUsers
    {
        int CountUser();
        IEnumerable<IdentityUser> GetUsers();
    }
}
