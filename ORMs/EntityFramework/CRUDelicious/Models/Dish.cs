using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CRUDelicious.Models
{
    public class Dish
    {
        public int DishId{get;set;}
        
        [Required]
        [MaxLength(45)]
        public string Name{get;set;}
        
        [Required]
        [MaxLength(45)]
        public string Chef{get;set;}
        
        [Required]
        [Range(1,5)]
        public int Tastiness{get;set;}
        
        [Required]
        public int Calories{get;set;}

        [Required]
        public string Description{get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}