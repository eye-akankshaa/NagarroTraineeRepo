using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_Data_Layer.Entities
{
    public class RentalAgreementEntity
    {

        [Key]
        [Required]
        public int AgreementID { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }


        
        public DateTime StartDate { get; set; }

     
        public DateTime EndDate { get; set; }


      
        public int RentalDuration { get; set; }

        public decimal TotalPrice { get; set; }

        public bool isReturnRequired { get; set; }

       
    }
}
