using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBorrowingSharedLayer.Models
{
    public class BookModel
    {

        [Key]
        [Required]
        public int BookId { get; set; }

        
        public string ? Name { get; set; }

       
        public float Rating{ get; set; }

       
        public string? Author { get; set; }

       
        public string? Genre { get; set; }

      
        public bool Is_Book_Available { get; set; }

       
        public string? Description { get; set; }

       
        public int  Lent_By_User_id { get; set; }

       
        public int Currently_Borrowed_By_User_id { get; set; }

      


    }
}
