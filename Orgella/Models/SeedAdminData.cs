using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class SeedAdminData
    {
        public static void EnsurePopulate(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Admins.Any())
            {
                context.Admins.AddRange(
                    new Admin
                    {
                        FirstName = "Lucas",
                        LastName = "Cichon",
                        Email = "lucas.cichon93@gmail.com",
                        PhoneNumber = 696547999,
                        Password = "maslo"
                    },
                    new Admin
                    {
                        FirstName = "Agnieszka",
                        LastName = "Lis",
                        Email = "aga.fox1999@gmail.com",
                        PhoneNumber = 601623145,
                        Password = "sekret"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
