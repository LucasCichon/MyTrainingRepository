using SportsStore.Models;
using System.Linq;
using Xunit;

namespace SportsStore.Test
{
    public class CartTest
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Przygotowanie - tworzenie produktów
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            //Przygotowanie - tworzenie koszyka
            Cart target = new Cart();
            //Działanie
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();
            //Asercje
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Przygotowanie - tworzenie produktów
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            //Przygotowanie - tworzenie koszyka
            Cart target = new Cart();
            //Działanie
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines.ToArray();
            //Asercje
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }
        [Fact]
        public void Can_Remove_Line()
        {
            //Przygotowanie - tworzenie produktów
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            //Przygotowanie - tworzenie koszyka
            Cart target = new Cart();
            //Przygotowanie - dodanie kilku produktów do koszyka
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);  
            target.AddItem(p3, 5);  
            target.AddItem(p2, 1);  

            //Działanie
            target.RemoveLine(p2);
            
            //Asercje
            Assert.Equal(0, target.Lines.Where(c => c.Product == p2).Count());
            Assert.Equal(2, target.Lines.Count());    
        }
        [Fact]
        public void Caltucale_Card_Total()
        {
            //Przygotowanie - tworzenie produktów
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M};
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 10M };
            //Przygotowanie - tworzenie koszyka
            Cart target = new Cart();
            //Przygotowanie - dodanie kilku produktów do koszyka
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
           
            //Działanie
            decimal resoult = target.ComputeTotalValue();

            //Asercje
            Assert.Equal(300M, resoult);
            
        }
        [Fact]
        public void Can_Clear_Contents()
        {
            //Przygotowanie - tworzenie produktów
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 10M };

            //Przygotowanie - tworzenie koszyka
            Cart target = new Cart();

            //Przygotowanie - dodanie kilku produktów do koszyka
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);

            //Działanie
            target.Clear();

            //Asercje
            Assert.Equal(0,target.Lines.Count());

        }
    }
}
