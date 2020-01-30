using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponents.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
    public class MemoryProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>
        {
            new Product{Name="Kajak", Price=275M},
            new Product{Name="Kamizelka ratunkowa", Price=48.95M},
            new Product{Name="Piłka nożna", Price=19.50M}
        };

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
