using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleLoginRegistration.Models
{
    public class Registration
    {
        public int Registrationid{get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name = "First Name")]
        public string fname{get;set;}

        [Required]
        [MinLength(2)]        
        [Display(Name = "Last Name")]
        public string lname{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email{get;set;}

        [Required]
        [MinLength(8,ErrorMessage ="Password must be 8 characters or longer!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password{get;set;}

        [NotMapped]
        [Compare("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string cpwd{get;set;}

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}
