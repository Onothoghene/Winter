using System.Collections.Generic;
using Winter.Models;

namespace Winter.Logic
{
    public interface IUsers
    {
        int CountUser();
        IEnumerable<ApplicationUser> GetUsers();
    }
}
