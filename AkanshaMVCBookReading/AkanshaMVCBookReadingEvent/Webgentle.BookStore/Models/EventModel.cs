using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webgentle.BookStore.Models
{
    public class EventModel : IEventModel
    {
        [Required(ErrorMessage = "Please Enter the DateTime of the Event")]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name = "Duration in hrs")]
        [Range(1, 4, ErrorMessage = " Duration should be 1-4 hours only")]
        public int Duration { get; set; }


        
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Please Enter the startTime of the Event")]
        [Display(Name = "StartTime")]
        public string startTime { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter the Title of the Event")]
        public string Title { get; set; }

        
        [Required(ErrorMessage = "Please Enter the Location of the Event")]
        public string Location { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please not entered more than 50 character")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessage = "Please not entered more than 500 character")]
        public string OtherDetails { get; set; }

        [Display(Name = "EventType")]
        public string eventType { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter the email Id of Invitees ")]
        [Display(Name = "Invite People by specifying their Email")]
        public string invitedTo { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter the EmailId of the Creator")]
        [Display(Name = "Organiser")]
        public string CreatedBy { get; set; }


    }
}
