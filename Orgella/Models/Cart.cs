using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>(); //lista obiektów CartLine

        public virtual void AddItem(Product product, int quantity)
        {
            //sprawdzamy czy lineCollection zawiera dany produkt przypisując jej obiekt z listy którego ID jest róne ID parametru metody
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public virtual decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Quantity * e.Product.Price);
        }
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
