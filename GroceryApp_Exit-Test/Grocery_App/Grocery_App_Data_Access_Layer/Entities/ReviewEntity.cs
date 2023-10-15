using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Data_Access_Layer.Entities
{
    public class ReviewEntity
    {
        [Required]
        [Key]
        public int ReviewId { get; set; }
        //FK
        public int RegisterId { get; set; }
        //FK
        public int ProductId { get; set; }
       // public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;

        //Navigation Property
        public RegisterEntity Register { get; set; } = new();
        public ProductEntity Product { get; set; } = new();
    }
}
