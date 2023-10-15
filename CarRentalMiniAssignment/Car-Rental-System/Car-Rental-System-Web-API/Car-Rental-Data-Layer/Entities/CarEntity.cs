using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Car_Rental_Data_Layer.Entities
{
    public class CarEntity
    {
        [Key]
        [Required]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Please enter your Full Name of Car Maker")]
        [Display(Name = "Car Maker")]
        public string Maker { get; set; }

       [Required(ErrorMessage = "Please enter your Car Model")]
        [Display(Name = "Car Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter your Rental Price Of Car")]
        [Display(Name = "Rental Price")]
        public long RentalPrice { get; set; }

        
        [Display(Name = "Availability Status")]
         public bool AvailabilityStatus { get; set; }
    }
}
