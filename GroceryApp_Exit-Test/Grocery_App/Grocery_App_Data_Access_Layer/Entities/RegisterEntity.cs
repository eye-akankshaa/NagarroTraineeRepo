using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery_App_Data_Access_Layer.Entities
{
    public class RegisterEntity
    {
        [Key]
        [Required]
        public int RegisterId { get; set; }

        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Email Id")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number")]
        [Display(Name = "Phone Number")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]

        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string Password { get; set; }

        public DateTime MemberSince { get; set; }
        public bool isAdmin { get; set; }

        //Navigation properties
        public ICollection<CartEntity> Carts { get; set; } = new List<CartEntity>();
        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
