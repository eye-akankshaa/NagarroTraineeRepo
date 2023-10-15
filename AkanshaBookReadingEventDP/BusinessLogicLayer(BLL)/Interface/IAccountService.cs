using BusinessLogicLayer_BLL_.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BusinessLogicLayer_BLL_.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO userModel);
        Task<SignInResult> LoginUserAsync(LoginDTO loginModel);
        Task SignOutAsync();
    }
}