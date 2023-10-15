using Car_Rental_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Business_Layer.IRepository
{
    public interface IUserRepository
    {
        UserEntity Login(LoginEntity user);
        UserEntity CurrentUser(string email);
        
      
    }
}
