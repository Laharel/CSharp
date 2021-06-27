using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class Form
    {
        [Required]
        [MinLength(4)]
        [Display(Name = "First Name")]
        public string fname{get;set;}

        [Required]
        [MinLength(4)]        
        [Display(Name = "Last Name")]
        public string lname{get;set;}

        [Required]
        [Range(0,99)]

        [Display(Name = "Age")]
        public int age{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email{get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password{get;set;}
    }
}