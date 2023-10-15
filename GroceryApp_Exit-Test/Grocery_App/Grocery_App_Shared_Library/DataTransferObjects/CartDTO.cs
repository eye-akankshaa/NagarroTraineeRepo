using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Shared_Library.Models
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int RegisterId { get; set; }


        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
