using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parafia.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        void AddCategory(Category category);
        void DeleteCategory(Category category);

        
        
    }
}
