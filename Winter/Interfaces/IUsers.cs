using System.Collections.Generic;
using Winter.DTO.Edit_Models;
using Winter.DTO.Input_Models;
using Winter.DTO.Output_Models;

namespace Winter.Logic
{
    public interface IUsers
    {
        long CountUser();
        IEnumerable<UserOM> GetUsers();
        bool AddUser(UserIM model, out int UserId);
        bool EditUser(UserEM model);
        bool DeleteUser(long UserId);
        UserOM GetUserDetail(int UserId);
        int GetUserId(string Email);
    }
}
