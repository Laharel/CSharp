using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2)]
        [Display(Name ="Your Name:")]
        public string name{get;set;}
        
        [Required]
        [Display(Name ="Dojo Location:")]
        public string location{get;set;}
        
        [Required]
        [Display(Name ="Favorite Language:")]
        public string language{get;set;}

        [Display(Name ="Comment (optional):")]
        [MaxLength(20)]
        public string comment{get;set;}
    }
}