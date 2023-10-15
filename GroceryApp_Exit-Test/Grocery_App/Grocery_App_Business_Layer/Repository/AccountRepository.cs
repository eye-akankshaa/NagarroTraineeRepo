using Grocery_App_Data_Access_Layer.Data;
using Grocery_App_Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Respositories
{
    public class RegisterRepository : IRegisterRepository
    {

        public readonly Grocery_Context _context;
        public RegisterRepository(Grocery_Context context)
        {
            _context = context;
        }
        public string Create(RegisterEntity user)
        {
            if (_context.Registers.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return "Already Exist";
            }
            user.MemberSince = DateTime.Now;
            _context.Registers.Add(user);
            _context.SaveChanges();
            return "Success";
        }

        public async Task<RegisterEntity> FindCurrentUser(string email)
        {
            return await _context.Registers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public RegisterEntity Login(LoginEntity user)
        {
            return _context.Registers.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
        }
    }
}
