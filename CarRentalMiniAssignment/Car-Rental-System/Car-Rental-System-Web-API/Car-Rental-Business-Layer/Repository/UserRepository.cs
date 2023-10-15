using Car_Rental_Business_Layer.IRepository;
using Car_Rental_Data_Layer.Data;
using Car_Rental_Data_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly CarRentalContext _context;
        public UserRepository(CarRentalContext context)
        {
            _context = context;
        }

        public UserEntity CurrentUser(string email)
        {
            return _context.User.Where(u => u.Email == email).FirstOrDefault();

        }

        public UserEntity Login(LoginEntity user)
        {
            return _context.User.Where(u => u.Email == user.Email).FirstOrDefault();
        }



        
    }
}
