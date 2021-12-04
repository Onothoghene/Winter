using System.Collections.Generic;
using Winter.API.DTO.Edit_Models;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
{
    public interface IUsers
    {
        UserOM GetUserByEmail(string Email);
        long CountUser();
        IEnumerable<UserOM> GetUsers();
        bool AddUser(UserIM model, out int UserId);
        bool EditUser(UserEM model);
        bool DeleteUser(long UserId);
        UserOM GetUserDetail(int UserId);
        int GetUserId(string Email);
    }
}
