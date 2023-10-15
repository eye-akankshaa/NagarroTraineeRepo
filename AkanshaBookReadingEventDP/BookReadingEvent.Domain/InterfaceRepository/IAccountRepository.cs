using BookReadingEvent.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookReadingEvent.Data.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, RegisterEntity registerEntity);
        Task<SignInResult> PasswordLoginAsync(LoginEntity loginModel);
        Task SignOutAsync();
    }
}