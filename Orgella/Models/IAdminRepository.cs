using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public interface IAdminRepository
    {
        IQueryable<Admin> Admins { get; }
    }
}
