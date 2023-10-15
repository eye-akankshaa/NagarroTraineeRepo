﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookReadingEvent.Domain.Entities
{
    public class CommentEntity
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
