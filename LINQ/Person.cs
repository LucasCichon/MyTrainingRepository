using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Person
    {
        public string Name;
        public string Gender;
        public int Age;

        public Person() { }

        public Person(string Name, string Gender, int Age)
        {
            this.Name = Name;
            this.Gender = Gender;
            this.Age = Age;
        }

        public static void PrintOut(List<Person>list)
        {
            int id = 1;
            string wyraz;
            foreach(Person p in list)
            {
                wyraz = id + ". " + p.Name + " Gender:" + p.Gender + ", Age:" + p.Age + ".";
                id++;
                Console.WriteLine(wyraz);
            }
        }
    }
}
