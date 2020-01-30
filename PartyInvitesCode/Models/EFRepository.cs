using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvitesCode.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<GuestResponse> Responses => context.Invites;

        public void AddResponse(GuestResponse response)
        {
            context.Invites.Add(response);
            context.SaveChanges();
        }
    }
}
