using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Car_Rental_Data_Layer.Entities
{
    public class UserEntity
    {

        [Key]
        [Required]
       public int UserId { get; set; }

       public string Name { get; set; }

       public string Email { get; set; }

       public long Phone { get; set; }

       public string Password { get; set; }

      public bool isAdmin { get; set; }

       
    }
}

