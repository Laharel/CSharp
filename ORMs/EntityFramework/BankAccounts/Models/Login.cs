using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}