using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.WebMVC.Models
{
    public class CommentViewModel
    {
        [ForeignKey("Event")]
        public int Id { get; set; }
        public int EventId { get; set; } //Event Id
        [Required(ErrorMessage = "Please write a comment before posting")]

        public string Comment { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
    }
}
