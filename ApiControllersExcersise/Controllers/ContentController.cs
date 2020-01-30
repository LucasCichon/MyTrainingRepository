using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiControllersExcersise.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiControllersExcersise.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("string")]
        public string GetString() => "To jest odpowiedź w postaci ciągu tekstowego";

        [HttpGet("object/{format?}")]
        [FormatFilter]
        //[Produces("application/json", "application/xml")]
        public Reservation GetObject()
        {
            Reservation res = new Reservation
            {
                ReservationId = 100,
                ClientName = "Agnieszka",
                Location = "Tarnau"
            };
            return res;
        } 

        [HttpPost]
        [Consumes("application/json")]
        public Reservation ReciveJson([FromBody] Reservation reservation)
        {
            reservation.ClientName = "Json";
            return reservation;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public Reservation ReciveXml([FromBody] Reservation reservation)
        {
            reservation.ClientName = "xml";
            return reservation;
        }
    }
}
