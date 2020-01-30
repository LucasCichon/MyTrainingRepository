using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models.ViewModels
{
    public class AdminListViewModel
    {
        public IEnumerable<Admin> Admins { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
