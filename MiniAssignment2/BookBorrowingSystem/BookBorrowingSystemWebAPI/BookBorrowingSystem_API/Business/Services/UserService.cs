using BookBorrowingSharedLayer.Models;
using DAL.Repository.Implementation;
using DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<UserModel> GetUserByEmailAsync(string email)
        {
            return userRepository.GetUserByEmailAsync(email);
        }

        
        public Task<UserModel> CurrentUser(string email)
        {
            return userRepository.CurrentUser(email);
        }

        
        public Task<UserModel> GetUserbyId(int id)
        {
            return userRepository.GetUserbyId(id);
        }

        public Task UpdateUserAsync(UserModel updateduser)
        {
            return userRepository.UpdateUserAsync(updateduser);
        }


    }
}
