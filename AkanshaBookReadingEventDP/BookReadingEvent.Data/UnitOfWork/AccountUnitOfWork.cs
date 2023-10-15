using BookReadingEvent.Data.Repository;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.Domain.UnitOfWorkInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Data.UnitOfWork
{
    public class AccountUnitOfWork : IAccountUnitOfWork
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        private IAccountRepository _accountRepository;

        public AccountUnitOfWork(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }

        public IAccountRepository Account
        {
            get
            {
                return _accountRepository ??= _accountRepository ?? new AccountRepository(_userManager,_loginManager);
            }
        }

       
    }
}
