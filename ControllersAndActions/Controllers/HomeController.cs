using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControllersAndActions.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");

        [HttpPost]
        //metoda RedirectToActionResult() otrzymuje dane od użytkownika za pomocą żądania HTTP POST i przekierowuje kliejnta do metody akcji Data(). wzorzec POST - przekierowanie - GET
        public RedirectToActionResult ReceiveForm(string name, string city)
        {
            TempData["name"] = name;
            TempData["city"] = city;
            return RedirectToAction(nameof(Data)); 
        }

        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;
            return View("Result", $"{name} mieszka w mieście {city}.");
        }
        //public ViewResult ReceiveForm(string name, string city) => View("Result", $"{name} mieszka w mieśćie {city}");


        //obiekt IActionResult nazywany wynikiem akcji opisuje dane, jakie chcemy otrzymać od kontrolera, np. wygenerowanie widoku, lub przekierowanie do innego adresu URL.
        //public IActionResult ReceiveForm(string name, string city) =>   
        //    new CustomHtmlResult
        //    {
        //        Content = $"{name} mieszka w mieście {city}."
        //    };

        //public void ReceiveForm(string name, string city)
        //{
        //    Response.StatusCode = 200;
        //    Response.ContentType = "text/html";
        //    byte[] content = Encoding.ASCII
        //        .GetBytes($"<html><body>{name} mieszka w mieście {city}. </body>"); // nie zamykac html ?
        //    Response.Body.WriteAsync(content, 0, content.Length);
        //}




        //Framework MVC dostarczy wartośći dla parametrów metody akcji przez automatyczne sprawdzenie obiektów kontekstu, między innymi Request.QueryString, Request.Form i RouteData.Values. 
       // public ViewResult ReceiveForm(string name, string city) => View("Result", $"{name} mieszka w mieście {city}.");
    }
}
