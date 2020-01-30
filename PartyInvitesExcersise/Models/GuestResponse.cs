using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesExcersise.Models
{
    public class GuestResponse
    {
        [Required (ErrorMessage = "Proszę podać swoje imię i nazwisko.")]
        public String Name { get; set; }
        [Required(ErrorMessage ="Proszę podać swój adres e-mail.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Proszę podać prawidłowy adres e-mail")]
        public String Email { get; set; }
        [Required(ErrorMessage ="Proszę podać swój numer telefonu.")]
        public String Phone { get; set; }
        [Required(ErrorMessage ="Proszę określić czy weźmiesz udział.")]
        public bool? WillAttend { get; set; }
    }
}
