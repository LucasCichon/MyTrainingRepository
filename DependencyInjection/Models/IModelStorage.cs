using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public interface IModelStorage 
    {
        IEnumerable<Product> Items { get; }
        Product this[string key] { get;set; }
        bool ContainsKey(string key);
        void RemoveItem(string key);
    }
}
