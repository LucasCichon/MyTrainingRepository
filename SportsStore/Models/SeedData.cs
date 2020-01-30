using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kajak",
                        Description = "Łódka przeznaczona dla jednej osoby",
                        Category = "Sporty wodne",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Kamizelka ratunkowa",
                        Description = "Chroni i dodaje uroku",
                        Category = "Sporty wodne",
                        Price = 48.95M
                    },
                    new Product
                    {
                        Name = "Piłka",
                        Description = "Zatwierdzone przez FIFA rozmiar i waga",
                        Category = "Piłka nożna",
                        Price = 19.50M
                    },
                    new Product
                    {
                        Name = "Flagi narożne",
                        Description = "Nadadzą twojemu boisku profesjonalny wygląd",
                        Category = "Piłka nożna",
                        Price = 34.95M
                    },
                    new Product
                    {
                        Name = "Stadion",
                        Description = "Składany station na 35 000 osób",
                        Category = "Piłka nożna",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Czapka",
                        Description = "Zwiększa efektywność mózgu o 75%",
                        Category = "Szachy",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Niestabilne krzesło",
                        Description = "Zmniejsza szanse przeciwnika",
                        Category = "Szachy",
                        Price = 75
                    },
                     new Product
                     {
                         Name = "aSzlachetny Rumak",
                         Description = "Kuń, a szaleje jak DZIK",
                         Category = "Szachy",
                         Price = 99999999999
                     },
                    new Product
                    {
                        Name = "Ludzka szachownica",
                        Description = "Przyjemna gra dla całej rodziny",
                        Category = "Szachy",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Błyszczący król",
                        Description = "Figura pokryta złotem i wysadzona diamentami",
                        Category = "Szachy",
                        Price = 1200
                    }, 
                    new Product
                    {
                        Name = "Złota Dama",
                        Description = "szalona tygrysica",
                        Category = "Szachy",
                        Price = 543268495
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
