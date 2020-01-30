using System;
using System.Threading.Tasks;

namespace dziedziczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            //Blat blat = new Blat(2, 3);
            //blat.WyswietlInformacje();
            Watki.zerowy();
            Watki.jedynkowy();

            Console.ReadLine();
        }
    }
    class Prostokat
    {
        protected int dlugosc;
        protected int szerokosc;

        public Prostokat(int dl, int sz)
        {
            dlugosc = dl;
            szerokosc = sz;
        }

        public int ObliczPowierzchnie()
        {
            return dlugosc * szerokosc;
        }

        public void WyswietlInformacje()
        {
            Console.WriteLine("Długość: {0}",dlugosc);
            Console.WriteLine("Szerokość: {0}",szerokosc);
            Console.WriteLine("Powierzchnia: {0}",ObliczPowierzchnie());
        }
    }
    class Blat : Prostokat
    {
        public Blat(int dlug, int szer) :base(dlug,szer){ }
        public int Koszt()
        {
            return ObliczPowierzchnie() * 50;
        }
        public void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine("Koszt: {0}", Koszt());
        }

    }
    static class Watki
    {
        public static async Task zerowy()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(0);
                }
            });
        }

        public static async Task jedynkowy()
        {
            await Task.Run(() =>
           {
               for (int i = 0; i < 1000; i++)
               {
                   Console.Write(1);
               }
           });
        }
    }
}
