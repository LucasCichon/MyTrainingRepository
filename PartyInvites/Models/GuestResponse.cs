using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Proszę podać swoje imię i nazwisko.")]
        public String Name { get; set; }
        [Required(ErrorMessage ="Proszę podać adres e-mail.")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Proszę podać prawidłowy adres e-mail.")]
        public String Email { get; set; }
        [Required(ErrorMessage ="Proszę podać numer telefonu.")]
        public String Phone { get; set; }
        [Required(ErrorMessage ="Proszę określić, czy weźmiesz udział.")]
        public bool? willAttend { get; set; }
    }
}
