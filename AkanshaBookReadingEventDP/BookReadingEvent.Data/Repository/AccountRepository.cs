using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BookReadingEvent.Domain.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using BookReadingEvent.Domain.Entities;
using System.Threading.Tasks;
using BookReadingEvent.Data.Data;
using BookReadingEvent.Domain.UnitOfWorkInterface;

namespace BookReadingEvent.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        
        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="loginManager"></param>
        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }
        /// <summary>
        /// Used to create the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        /// 
        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user,RegisterEntity registerEntity)
        {
            var result = await _userManager.CreateAsync(user, registerEntity.Password );
            return result;

        }
        /// <summary>
        /// used to login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<SignInResult> PasswordLoginAsync(LoginEntity loginModel)
        {
            var result =await _loginManager.PasswordSignInAsync(loginModel.EmailAddress, loginModel.Password, loginModel.RememberMe, false);
            return result;
        }

        /// <summary>
        /// used to sign out the user
        /// </summary>
        /// <returns></returns>
        public async Task SignOutAsync()
        {
            await _loginManager.SignOutAsync();
        }
    }
}
