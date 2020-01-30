using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MvcModels.Models
{
    public interface IRepository
    {
        IEnumerable<Person>People { get; }
        Person this [int id] { get;set; }
    }
    public class MemoryRepository : IRepository
    {
        private Dictionary<int, Person> people = new Dictionary<int, Person>
        {
            [1] = new Person
            {
                PersonId = 1,
                FirstName = "Bartek",
                LastName = "Nowak",
                Role = Role.Administrator
                
                
            },
            [2] = new Person
            {
                PersonId = 2,
                FirstName = "Anna",
                LastName = "Grabowska",
                Role = Role.Użytkownik
            },
            [3] = new Person
            {
                PersonId = 3,
                FirstName = "Jan",
                LastName = "Kowalski",
                Role = Role.Użytkownik
            },
            [4] = new Person
            {
                PersonId = 4,
                FirstName = "Maria",
                LastName = "Malinowska",
                Role = Role.Gość
            }
        };

        public Person this[int id] { 
            get 
            {
                return people.ContainsKey(id) ? people[id] : null;
            }
            set { people[id] = value; }
        }

        public IEnumerable<Person> People => people.Values;
    }
}
