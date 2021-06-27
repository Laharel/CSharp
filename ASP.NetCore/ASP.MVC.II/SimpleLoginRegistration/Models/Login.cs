
using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class Login
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password{get;set;}
    }
}