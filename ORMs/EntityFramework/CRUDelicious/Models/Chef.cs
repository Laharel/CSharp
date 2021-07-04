using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
    public class Chef
    {
        public int ChefId{get;set;}
        
        [Required]
        public string FirstName{get;set;}

        [Required]
        public string LastName{get;set;}

        [Required]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]
        [Range(typeof(DateTime),"02/07/1940","02/07/2003")]
        [Display(Name ="Date of Birth")]
        public DateTime DoB{get;set;}

        public int Age{get;set;}

        public List<Dish> Dishes {get;set;}
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}