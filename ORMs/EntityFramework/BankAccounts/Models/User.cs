using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class User
    {
        public int UserId { get; set;}

        [Required]
        [MinLength(4)]
        [MaxLength(45)]
        [Display(Name ="First Name")]
        public string fname { get; set;}
        
        [Required]
        [MinLength(4)]
        [MaxLength(45)]
        [Display(Name ="Last Name")]
        public string lname { get; set;}
        
        [Required]
        [MinLength(4)]
        [MaxLength(45)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}
        
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [NotMapped]
        public string CP { get; set;}
        
        public int TransactionId {get;set;}
        public List<Transaction>  Transactions{get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}