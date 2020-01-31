using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Add(5);
            list.Add(8);
            list.Add(9);
            
            foreach(int l in list)
            {
                Console.WriteLine(l);
            }

            List<Person> PList = new List<Person>()
            {
                new Person{Name = "Lucas", Gender = "M", Age = 26},
                new Person{Name = "Agnieszka", Gender = "K", Age = 20},
                new Person{Name = "Daniel", Gender = "M", Age = 20},
                new Person{Name = "Peter", Gender = "M", Age = 24},
                new Person{Name = "Tina", Gender = "K", Age = 29},
                new Person{Name = "Laura", Gender = "K", Age = 21},
                new Person{Name = "Mateusz", Gender = "M", Age = 31}
            }.ToList<Person>();


            Console.WriteLine("23<=x<=29");
            List<Person> LinqList = PList.Select(p => p).Where(p => p.Age >= 23 && p.Age<=29).ToList();
            Person.PrintOut(LinqList); Console.WriteLine("\n\n");

            Console.WriteLine("RemoveList before remove");
            List<Person> RemoveList = PList.Select(p => p).ToList();

            Console.WriteLine("Remove: x>=29");
            Person.PrintOut(RemoveList); Console.WriteLine("\n\n");
            RemoveList.RemoveAll(x => x.Age >= 29);
            Person.PrintOut(RemoveList); Console.WriteLine("\n\n");






            Console.ReadLine();
        }
        
        
        public static int GiveBack(int x)
        {
            if (x > 100) return 100;
            else return x;
        }
    }
}
