using BookBorrowingSharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByEmailAsync(string email);

        Task<UserModel> CurrentUser(string email);

        Task UpdateUserAsync(UserModel updateduser);

        Task<UserModel> GetUserbyId(int id);
    }
}
