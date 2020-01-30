using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{   
    //Klasa ApplicationDbContext dziedziczy po klasie DbContext i dodaje właściwośći używane w celu odczytywania oraz zapisywania danych aplikacji.
    public class ApplicationDbContext : DbContext // Klas bazowa DbContext zapewnia dostęp do funkcjonalności Entity Framework
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        public DbSet<Product> Products { get; set; } // właściwość Products zapewni dostęp do obiektów typu Product w bazie danych.
        public DbSet<Admin> Admins { get; set; }
    }
}
