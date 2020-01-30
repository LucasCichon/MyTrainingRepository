using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orgella.Models;

namespace Orgella
{
    public class Startup
    {   //konstruktor wczytujący ustawienia konfiguracyjne z pliku appsettings.json i udostępniający je poprzez obiekt implementujący interfejs IConfiguration.
        //za pomocą obiektu implementującego interfejs IConfiguration mamy dostęp do pliku appsettings.json który zawiera connectionString do bazy danych
        public IConfiguration Configuration { get; } 
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:OrgellaProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();// użycie rzeczywistego repozytorium. Komponenty aplikacji używające interfejsu IProductRepository, który w tym momencie jet po prostu kontrolerem Product, będą w chwili tworzenia otrzymywały obiekt EFProductRepository, zapewniający dostęp do informacji w bazie danych.
            services.AddTransient<IAdminRepository, EFAdminRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Produkty/Strona{productPage}",
                    defaults: new { controller = "Product", action = "List" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=List}/{id?}");
            });
        SeedData.EnsurePopulated(app);
        SeedAdminData.EnsurePopulate(app);
        }
    }
}
