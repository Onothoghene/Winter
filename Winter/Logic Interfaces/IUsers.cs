using System.Collections.Generic;
using Winter.Models;

namespace Winter.Logic
{
    public interface IUsers
    {
        long CountUser();
        IEnumerable<UserOM> GetUsers();
        bool AddUser(UserIM model);
        bool EditUser(UserEM model);
        bool DeleteUser(long UserId);
        UserOM GetUserDetail(long UserId);
    }
}
