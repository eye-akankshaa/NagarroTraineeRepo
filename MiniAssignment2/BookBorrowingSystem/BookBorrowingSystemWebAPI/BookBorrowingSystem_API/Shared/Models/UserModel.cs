using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingSharedLayer.Models
{
    public class UserModel
    {
        [Key]
        [Required] 
        public int UserId { get; set; }

       
        public string? Name { get; set; }

       
        public string? Username { get; set; }

    
        public string ? Password { get; set; }

       
        public int Tokens_Available { get; set; }

       
     
        
    }
}
