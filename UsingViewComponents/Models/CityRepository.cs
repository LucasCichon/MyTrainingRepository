using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City city);
    }
    public class MemoryCityRepository : ICityRepository
    {
        private List<City> cities = new List<City>
        {
            new City{ Name = "Londyn", Country = "Wielka Brytania", Population=8539000L},
            new City{ Name = "Nowy Jork", Country = "USA", Population=8406000L},
            new City{ Name = "San Jose", Country = "USA", Population=998537L},
            new City{ Name = "Paryż", Country = "Francja", Population=2244000L}
        };

        public IEnumerable<City> Cities => cities;

        public void AddCity(City city)
        {
            cities.Add(city);
        }
    }
}
