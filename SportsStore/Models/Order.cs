using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Proszę podać imię i nazwisko.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać pierwszy wiersz adresu.")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę miasta.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę Województwa.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę kraju.")]
        public string Country { get; set; } 

        [Required(ErrorMessage ="Proszę podać odres")]
        public string Zip { get; set; }

        public bool GiftWrap { get; set; }
    }
}
