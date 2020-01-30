using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parafia.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<string> subcategories { get; set; }
    }
}
