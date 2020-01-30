using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UsingViewComponents.Components;
using UsingViewComponents.Models;
using Xunit;

namespace UsingViewComponents.Test
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            //Przygotowanie.
            var mockRepository = new Mock<ICityRepository>();   //tworzymy imitacje repozytorium
            mockRepository.SetupGet(m => m.Cities).Returns(new List<City>   //wkładamy do imitacji repozytorium nową listę miast
            {
                new City{Population = 100},
                new City{Population = 20000},
                new City{Population = 1000000},
                new City{Population = 500000}
            });
            var viewComponent = new CitySummary(mockRepository.Object); //przekazujemy imitacje jako parametr konstruktora klasy CitySummary, która przyjmuje jako parametr obiekt klasy dziedziczącej po interfejsie ICityRepository

            //Działanie.
            ViewViewComponentResult result = viewComponent.Invoke(false) as ViewViewComponentResult; // obiektowi rezult przypisujemy wartość wyniku metody Invoke z klasy CitySummary. Obiekt result staje się obiektem wyniku metody.

            //Asercje.
            Assert.IsType(typeof(CityViewModel), result.ViewData.Model);    //sprawdzenie czy Typ obiekty result jest Typem CityViewModel
            Assert.Equal(4, ((CityViewModel)result.ViewData.Model).Cities);
            Assert.Equal(1520100, ((CityViewModel)result.ViewData.Model).Population);
        }
    }
}
