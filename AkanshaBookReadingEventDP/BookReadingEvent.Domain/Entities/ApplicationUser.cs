using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookReadingEvent.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        
    }
}
