using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Data_Access_Layer.Entities
{
    public class CartEntity
    {
        [Required]
        [Key]
        public int CartId { get; set; }
        //FK
        public int RegisterId { get; set; }
        //FK
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //Navigation Property
       virtual public RegisterEntity Register { get; set; } = new();
      virtual  public ProductEntity Product { get; set; } = new();
    }
}
