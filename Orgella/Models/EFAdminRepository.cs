using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class EFAdminRepository : IAdminRepository
    {
        private ApplicationDbContext context;
        public EFAdminRepository(ApplicationDbContext ctx) => context = ctx;
        public IQueryable<Admin> Admins => context.Admins;
    }
}
