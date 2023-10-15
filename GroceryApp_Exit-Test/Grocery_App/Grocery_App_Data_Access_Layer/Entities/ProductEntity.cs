using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Data_Access_Layer.Entities
{
    public class ProductEntity
    {
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Category")]
        [Display(Name = " Product Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter Quantity")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter Discount")]
        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [Required(ErrorMessage = "Please enter specifification")]
        [Display(Name = "Product Specification")]
        public string Specification { get; set; }

        public string Data { get;set; }


        // Navigation properties

        public ICollection<CartEntity> Carts { get; set; } = new List<CartEntity>();
        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
