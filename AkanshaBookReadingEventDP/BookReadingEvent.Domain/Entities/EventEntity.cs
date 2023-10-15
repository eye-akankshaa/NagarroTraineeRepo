using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReadingEvent.Domain.Entities
{
    public class EventEntity :BaseEventEntity
    {
        [Required(ErrorMessage = " Please Enter Title of the book")]
        [Display(Name = "Title of the Book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Event Date")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter the start time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please Enter the Location of the Event")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [StringLength(50, ErrorMessage = "Please not entered more than 50 character")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [StringLength(500, ErrorMessage = "Please not entered more than 500 character")]
        [Display(Name = "Other Details")]
        public string OtherDetails { get; set; }

        [Range(1, 4, ErrorMessage = " Duration should be 1-4 hours only")]
        public int? Duration { get; set; }

        [Display(Name = "Organiser")]
        [Required(ErrorMessage = "Please Enter your name")]
        public string Organiser { get; set; }


        [Display(Name = "Type of Event")]
        public string EventType { get; set; }


        [Display(Name = "Invite People by specifying their Email")]
        public string Invitees { get; set; }

        public string CreatedBy { get; set; }

        [ForeignKey("EventId")]
        public ICollection<CommentEntity> Comments { get; set; }

        
    }
}
