using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReadingEvent.WebMVC.Models
{
    public class EventViewModel :BaseEventViewModel
    {
       
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

      
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        
        public string Location { get; set; }

      
        public string Description { get; set; }
      
        public string OtherDetails { get; set; }

      
        public int? Duration { get; set; }

        
        public string Organiser { get; set; }


     
        public string EventType { get; set; }


     
        public string Invitees { get; set; }

        public string CreatedBy { get; set; }
        
        [ForeignKey("EventId")]
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
