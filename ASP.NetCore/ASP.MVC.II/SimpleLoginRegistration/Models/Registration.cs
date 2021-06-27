using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class Registration
    {
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
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password{get;set;}

        [Required]
        [Compare("password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string cpwd{get;set;}
    }
}
