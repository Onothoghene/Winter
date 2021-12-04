using API.Winter.DTO;
using API.Winter.DTO.Output_Models;
using System.Threading.Tasks;

namespace API.Winter.Logic.Interfaces
{
    public interface IAccount
    {
        Task<bool> RegisterUser(RegistrationModel model);
        Task<UserOM> LoginUser(LoginModel model);
        Task<string> ChangePassword(ChangePasswordModel model);
        Task<bool> Logout(string Email);
    }
}
