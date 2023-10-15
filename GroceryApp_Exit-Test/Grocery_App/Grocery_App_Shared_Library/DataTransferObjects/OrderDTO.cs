using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Shared_Library.Models
{
    public class OrderDTO
    {
        
        public int RegisterId { get; set; }

        public int QuantityOfItems { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }

        public int[] UpdatedQuantities { get; set; }
    }
}
