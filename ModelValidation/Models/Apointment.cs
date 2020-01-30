using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;



namespace ModelValidation.Models
{
    public class Apointment
    {
        [Required]
        [Display(Name = "name")]
        public string ClientName { get; set; }
        
        [UIHint("Date")]
        [Required(ErrorMessage ="Proszę podać datę.")]
        [Remote("ValidateDate","Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true",ErrorMessage ="Zaakceptowanie warunków jest wymagane.")]
        [MustBeTrue(ErrorMessage ="Zaakceptowanie warunków jest wymagane.")]
        public bool TermsAccepted { get; set; }
    }
}
