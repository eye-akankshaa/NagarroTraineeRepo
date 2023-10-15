using BookReadingEvent.Data.Repository;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_BLL_.Services
{
    public class AccountService : IAccountService
    {

        // private readonly IAccountRepository _accountRepository;
        private readonly IAccountUnitOfWork _accountUnitOfWork;
       
        public AccountService(IAccountUnitOfWork accountUnitOfWork)
        {
            _accountUnitOfWork = accountUnitOfWork;
        }

        /// <summary>
        /// Used to create the user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(RegisterDTO userModel)
        {
            var user = new ApplicationUser()
            {
               FullName = userModel.FullName,
                Email = userModel.EmailAddress,
                UserName = userModel.EmailAddress,

            };
            var userModelEntity = new RegisterEntity()
            {
                FullName = userModel.FullName,
                EmailAddress=userModel.FullName,
                Password=userModel.Password,
                

            };

            var id = await _accountUnitOfWork.Account.CreateUserAsync(user, userModelEntity);
            return id;
        }

        /// <summary>
        /// used to login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<SignInResult> LoginUserAsync(LoginDTO loginModel)
        {
            var user = new LoginEntity()
            {
                EmailAddress = loginModel.EmailAddress,
                Password = loginModel.Password,
                RememberMe = loginModel.RememberMe,
            };
            var result = await _accountUnitOfWork.Account.PasswordLoginAsync(user);

            return result;
        }


        /// <summary>
        /// used to sign out the user
        /// </summary>
        /// <returns></returns>
        public async Task SignOutAsync()
        {
            await _accountUnitOfWork.Account.SignOutAsync();
        }

    }
}
