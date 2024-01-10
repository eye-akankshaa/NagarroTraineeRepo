using BookBorrowingSharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IUserService
    {
       
       
         Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel>CurrentUser(string email);
        Task UpdateUserAsync(UserModel updatedUser);
        Task<UserModel> GetUserbyId(int id);

    }
}
