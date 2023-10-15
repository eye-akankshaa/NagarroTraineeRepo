using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Data_Access_Layer.Entities
{
    public class OrderEntity
    {
        [Required]
        [Key]
        public int OrderId { get; set; }
        //FK
       
        public int RegisterId { get; set; }
        public DateTime OrderDate { get; set; }

        public int QuantityOfItems { get; set; }
        public int TotalPrice { get; set; }

        //Navigation Properties
        virtual public RegisterEntity Register { get; set; } = new();
        
    }
}
