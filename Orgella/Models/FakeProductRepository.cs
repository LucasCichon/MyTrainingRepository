using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class FakeProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>
        {
            new Product {Name="Saxofon", Price=11000M},
            new Product {Name="Pianino", Price=6000M},
            new Product {Name="Fortepian", Price=26000M},
            new Product {Name="Klarnet", Price=1500M},
            new Product {Name="harmonijka", Price=20.50M},
            new Product {Name="Trabka", Price=3200M}
        }.ToList();

        //metoda AsQueryable() jest używana w celu przeprowadzenia konwercji kolekcji na postać typu IQueryable<t> wymaganą do zaimplementowania interfejsu IProductRepository.
        public IQueryable<Product> Products => products.AsQueryable<Product>(); 
    }
}
