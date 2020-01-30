using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesExcersise.Models
{
    public class City
    {
        
        [Display(Name="Miasto:")]
        public string Name { get; set; }
        [Display(Name="Kraj:")]
        public string Country { get; set; }

        [Display(Name="Populacja:")]
        [DisplayFormat(DataFormatString ="{0:F2}",ApplyFormatInEditMode =true)]
        public int? Population { get; set; }

        [Display(Name = "Uwagi")]
        public string Notes { get; set; }
    }
}
