using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Parafia.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private Dictionary<string, Category> categories;

        public CategoryRepository()
        {
            categories = new Dictionary<string, Category>();
            new List<Category>
            {
                new Category { Name = "Strona główna" },
                new Category { Name = "Parafia" },
                new Category { Name = "Ogłoszenia duszpasterskie" },
                new Category { Name = "Porządek nabożeństw"  }
            }.ForEach(c => AddCategory(c));
        }

        public IEnumerable<Category> Categories => categories.Values;

        public void AddCategory(Category category)
        {
            categories[category.Name] = category;
        }

        public void DeleteCategory(Category category)
        {
            categories.Remove(category.Name);
        }

       
    }
}
