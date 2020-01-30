using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesExcersise.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City city);
    }
    public class Repository : IRepository
    {
        private List<City> cities = new List<City>()
        {
            new City{Name = "Londyn", Country = "Wielka Brytania", Population = 8539000},
            new City{Name = "Nowy Jork", Country = "USA", Population = 8406000},
            new City{Name = "San Jose", Country = "USA", Population = 998537},
            new City{Name = "Paryż", Country = "Francja", Population = 2244000}
        };
        public IEnumerable<City> Cities => cities;

        public void AddCity(City city)
        {
            cities.Add(city);
        }
    }
}
