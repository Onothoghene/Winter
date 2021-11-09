using System.Threading.Tasks;
using Winter.API.DTO;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
{
    public interface IAccount
    {
        Task<bool> RegisterUser(RegistrationModel model);
        Task<UserOM> LoginUser(LoginModel model);
        Task<string> ChangePassword(ChangePasswordModel model);
    }
}
