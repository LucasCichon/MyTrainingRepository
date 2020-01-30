using System;
using System.Collections.Generic;

namespace IEnumerableExcersise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("maja");
            list.Add("kaja");
            list.Add("waja");
            list.Add("saja");
            list.Add("cooooo");

            foreach(string s in list)
            {
                Console.WriteLine(s);
            }

            Salon salon = new Salon();
            salon.lista.Add(new Auto("Passerati"));
            salon.lista.Add(new Auto("BMW"));
            salon.lista.Add(new Auto("Ferrari"));
            salon.lista.Add(new Auto("Mercedes"));

            foreach (Auto a in salon)
            {
                Console.WriteLine(a.Name);
            }
            
            
            
            List<Auto> lista = new List<Auto>()
            {
                new Auto("Miecio"),
                new Auto("Pasacio")
            };

            var enumerator = lista.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine($"A is {enumerator.Current.Name}");
            }

            //foreach (Auto a in lista)
            //{
            //    Console.WriteLine(a.Name);
            //}

            Console.ReadLine();
        }
    }
}
