using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Shared_Library.Models
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int RegisterId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
    }
}
