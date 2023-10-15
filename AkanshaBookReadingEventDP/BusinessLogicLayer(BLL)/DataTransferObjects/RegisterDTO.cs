using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogicLayer_BLL_.DataTransferObjects
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Please enter your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a valid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
