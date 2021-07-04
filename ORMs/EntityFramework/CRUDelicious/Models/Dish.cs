using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
    public class Dish
    {
        public int DishId{get;set;}
        
        [Required]
        [MaxLength(45,ErrorMessage ="Maximum Characters for Name is 45")]
        public string Name{get;set;}
        
        public int ChefId{get;set;}
        public Chef Cook{get;set;}
        
        [Required]
        [Range(1,5)]
        public int Tastiness{get;set;}
        
        [Required]
        [Range(1,9999999)]
        public int Calories{get;set;}

        [Required]
        public string Description{get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}