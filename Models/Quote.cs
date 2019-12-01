using System;
using System.ComponentModel.DataAnnotations;
namespace quoting_dojo.Models
{
    public class Quote
    {
        [Required]
        [Display(Name = "Your Name: ")]
        public string Name {get;set;}

        [Required]
        [Display(Name = "Your Quote: ")]
        public string Content{get;set;}
        public DateTime Created_at {get;set;}
    }
}