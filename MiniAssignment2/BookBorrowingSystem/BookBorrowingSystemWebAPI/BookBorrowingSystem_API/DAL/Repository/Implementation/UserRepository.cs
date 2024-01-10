using BookBorrowingDataLayer.Data;
using BookBorrowingSharedLayer.Models;
using DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Implementation
{
    public class UserRepository:IUserRepository
    {
        private readonly BookBorrowingDbContext dbContext;

        public UserRepository(BookBorrowingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<UserModel> GetUserByEmailAsync(string username)
        {
            var user = await dbContext.User.FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<UserModel> CurrentUser(string email)
        {
           return  await dbContext.User.FirstOrDefaultAsync(p => p.Username ==email);
           
        }

        public async Task<UserModel> GetUserbyId(int id)
        {
            return await dbContext.User.FirstOrDefaultAsync(p => p.UserId == id);

        }

        public async Task UpdateUserAsync(UserModel updateduser)
        {
            dbContext.User.Update(updateduser);
            await dbContext.SaveChangesAsync();
        }
    }
}
