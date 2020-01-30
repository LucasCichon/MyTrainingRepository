using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            var products = new[] 
            {
                new {Name = "Kajak", Price = 275M},
                new {Name = "Kamizelka ratunkowa", Price = 48.95M},
                new {Name = "Piłka nożna", Price = 19.50M},
                new {Name = "Flaga narożna", Price = 34.90M}
            };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }

        //public async Task<ViewResult> Index()
        //{
        //    long? length = await MyAsyncMethod.GetPageLength();
        //    return View(new string[] { $"Długość: {length}" });
        //}

        //public ViewResult Index()
        //{
        //    var prducts = new[]
        //    {
        //        new{Name = "Kajak", Price = 275M},
        //        new{Name = "kamizelka ratunkowa", Price = 48.95M},
        //        new{Name = "Piłka nożna", Price = 19.50M},
        //        new{Name = "Flaga narożna", Price = 34.90M}
        //    };
        //    return View(prducts.Select(p => p?.GetType().Name));
            
        //}

        //public ViewResult Index()
        //{
        //    var names = new[]
        //    {
        //        "Kajak","Kamizelka ratunkowa","Piłka nożna"
        //    };
        //    return View(names);
        //}

        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.NameBegisWithK.ToString()));
        //public ViewResult Index()
        //{
        //    return View(Product.GetProducts().Select(p => p?.Name));
          //  Product[] productArray =
          //{
          //      new Product{Name = "Kajak", Price = 275M},
          //      new Product{Name = "Kamizelka ratunkowa", Price = 48.95M},
          //      new Product{Name = "Piłka nożna", Price = 19.50M},
          //      new Product{Name = "Flaga narożna", Price = 34.95M}
          //  };

          //  decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
          //  decimal nameFilterTotal = productArray.Filter(p=>(p?.Name?[0])=='P').TotalPrices();

          //  return View("Index", new String[] { $"Razem według wartośći: {priceFilterTotal:C2}",
          //  $"Razem według nazwy: {nameFilterTotal:C2}"});

           // bool FilterByPrice(Product p)
           // {
           //     return (p?.Price ?? 0) >= 20;
           // }

           // Product[] productArray =
           //{
           //     new Product{Name = "Kajak", Price = 275M},
           //     new Product{Name = "Kamizelka ratunkowa", Price = 48.95M},
           //     new Product{Name = "Piłka nożna", Price = 19.50M},
           //     new Product{Name = "Flaga narożna", Price = 34.95M}
           // };

           // Func<Product, bool> nameFilter = delegate (Product prod)
           // {
           //     return prod?.Name?[0] == 'P';
           // };
           // decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices();
           // decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices();

           // return View("Index", new String[] { $"Razem według wartośći: {priceFilterTotal:C2}",
           // $"Razem według nazwy: {nameFilterTotal:C2}"});

            //Product[] productArray =
            //{
            //    new Product{Name = "Kajak", Price = 275M},
            //    new Product{Name = "Kamizelka ratunkowa", Price = 48.95M},
            //    new Product{Name = "Piłka nożna", Price = 19.50M},
            //    new Product{Name = "Flaga narożna", Price = 34.95M}
            //};
            //decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal nameFilterTotal = productArray.FilterByName('P').TotalPrices();

            //return View("Index", new string[] { $"Razem wszystko: {priceFilterTotal:C2}",
            //    $"Razem P: {nameFilterTotal:C2}"});


            //Product[] productArray =
            //{
            //    new Product{Name = "Kajak", Price = 275M},
            //    new Product{Name = "Kamizelka ratunkowa", Price = 48.95M},
            //    new Product{Name = "Piłka nożna", Price = 19.50M},
            //    new Product{Name = "Flaga narożna", Price = 34.95M}
            //};
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //return View("Index", new string[] { $"Razem tablica: {arrayTotal:C2}" });


            //ShoppingCart cart = new ShoppingCart
            //{
            //    Products = Product.GetProducts()
            //};
            //Product[] productArray =
            //{
            //    new Product{Name = "Kajak", Price = 275M},
            //    new Product{Name = "Kamizelka ratunkowa", Price = 48.95M}
            //};
            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.TotalPrices();
            //return View("Index", new string[]
            //{
            //    $"Razem koszyk: {cartTotal:C2}",
            //    $"Razem tablica: {arrayTotal:C2}"
            //});

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //decimal cartTotal = cart.TotalPrices();
            //return View("Index", new string[] { $"Razem: {cartTotal:C2}" });

            //object[] data = new object[] { 275M, 29.95M, "jabłka", "pomarańcze", 100, 10 };
            //decimal total = 0;
            //for(int i=0; i<data.Length; i++)
            //{
            //    switch(data[i])
            //    {
            //        case decimal decimalValue: //dwukropek!!!
            //            total += decimalValue;
            //            break;
            //        case int intValue when intValue > 50: //dwukropek !!!
            //            total += intValue;
            //            break;
            //    }
            //}
            //return View("Index", new string[] { $"Razem: {total:C2}" });

            //object[] data = new object[] { 275M, 29.95M, "jabłka", "pomarańcze", 100, 10 };
            //decimal total = 0;
            //for(int i=0; i<data.Length; i++)
            //{
            //    if (data[i] is decimal d)
            //    {
            //        total += d;
            //    }
            //}
            //return View("Index", new string[] { $"Raze,: {total:C2}" });

            //Dictionary<string, Product> products = new Dictionary<string, Product>
            //{
            //    ["Kayak"] = new Product { Name = "Kajak", Price = 275M },
            //    ["Lifejacket"] = new Product { Name = "Kamizelka ratunkowa", Price = 48.95M}
            //};
            //return View ("Index",  products.Keys);


            //return View("Index", new string[] { "Bartek", "Janek", "Alicja" });



            //List<string> results = new List<string>();
            //foreach(Product p in Product.GetProducts())
            //{
            //    string name = p?.Name ??"<brak>";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<brak>";
            //    string category = p?.Category;
            //    results.Add(string.Format($"Produkt:{name}, cena: {price:C2}, Powiązanie: {relatedName}, Kategoria: {category}"));
            //}


            //return View(results);
        //}
    }
}
