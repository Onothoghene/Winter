using System.Collections.Generic;
using Winter.Models;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.Logic
{
    public interface IUsers
    {
        long CountUser();
        IEnumerable<UserOM> GetUsers();
        bool AddUser(UserIM model, out long UserId);
        bool EditUser(UserEM model);
        bool DeleteUser(long UserId);
        UserOM GetUserDetail(long UserId);
        long GetUserId(string Email);
    }
}
