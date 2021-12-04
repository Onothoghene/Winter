using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
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
