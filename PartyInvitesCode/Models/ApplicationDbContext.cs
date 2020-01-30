using Microsoft.EntityFrameworkCore;

namespace PartyInvitesCode.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("FileName=./PartyInvites.db");
        }
        public DbSet<GuestResponse> Invites { get; set; }
    }
}
