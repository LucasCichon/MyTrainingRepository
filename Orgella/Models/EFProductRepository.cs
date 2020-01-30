using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx) => context = ctx;

        //mapowanie właściwości Products zdefiniowanej przez interfejs IProductRepository na właściwość Products zdefiniowanę przez klasę ApplicationDbContext. Właściwość Products w klasie kontekstu zwraca obiet typu DbSet<Product> implementujący interfejs IQueryable<T> i ułątwiający zaimplementowanie interfejsu IProductRepository podczas użycia Entity Framework Core. Dzięki temu mamy pewność, że zapytania wykonywane do bazy danych będą pobierały jedynie wymgane obiekty.
        public IQueryable<Product> Products => context.Products; 
        
    }
}
