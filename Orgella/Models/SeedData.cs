using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class SeedData
    {
        //Metoda statyczna EnsurePopulate() otrzymuje argument IApplicationBuilder, który jest klasą używaną w metodzie Configure() klasy Startupp do zarejestrowania klasy oprogramowania pośredniczącego w celu obsługi żądań HTTP. Ma to zagwarantować że baza danych będzie miała pewną zawartość.
        public static void EnsurePopulated(IApplicationBuilder app) 
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Gibson Les Paul",
                        Description = "Jedna z najbardziej rozpoznawalnych na świecie gitar elektrycznych.Wielu gitarzystów po wzięciu do rąk Gibsona z serii Les Paul zakochuje się w nich i zapewniam że nie jest to nic dziwnego.",
                        Category = "Gitary elektryczne",
                        Price = 3600M
                    },
                    new Product
                    {
                        Name = "Selmer Axos",
                        Description = "Instrument ten produkowany jest w fabryce mieszczącej się w Mantes-la-Ville we Francji, tej samej, z której wyszły wszystkie inne modele od roku 1922.",
                        Category = "Dęte drewniane",
                        Price = 11000M
                    },
                    new Product
                    {
                        Name = "Steinway & Sons",
                        Description = " „D” (274 cm, „Concert Grand”), wywodzi się z poprzedniego modelu, znanego pod nazwą „Centennial grand” i budowanego od lat 1870-ych (prawdopodobnie od roku 1875/76). Ten fortepian uznaje się dzisiaj za bezpośredniego poprzednika współczesnego fortepianu „D”, mimo iż długość tego modelu wynosiła zaledwie 8’9″ (267 cm).",
                        Category = "Fortepiany",
                        Price = 299000M
                    },
                    new Product
                    {
                        Name = "Bach TR300 H",
                        Description = "Bardzo dobra trąbka renomowanej firmy Bach, sprawdzająca się zarówno dla zaczynających swą przygodę z muzyką, jak również dla doświadczonych zawodników, bardziej wymagających, poszkujących ekstrymalnych wrażeń esteetyki dźwięku oraz precyzji wykonania.",
                        Category = "Instrumenty dęte",
                        Price = 2500M
                    },
                    new Product
                    {
                        Name = "Hohner Bravo III",
                        Description = "Flagowy model firmy Hohnner. Nowa seria BRAVO cechuje się nowoczesnych wyglądem, cichym działaniem klawiszy (technologia SILENTKEY) i polepszoną wygodą gry.",
                        Category = "Akordeony",
                        Price = 7390M
                    },
                    new Product
                    {
                        Name = "Yamaha RDP2F5 Rydeen BLG",
                        Description = "Zestaw perkusji akustycznej od producenta Yamaha, z serii Raydeen. Raydeen to następca niezwykle popularnej serii Gigmaker. To trwałe i bardzo dobrze wykonane zestawy perkusyjne, nie tylko dla poczatkujących perkusistów. 6-warstwowe korpusy wykonane z topoli, sprawią, że poza wytrzymałością zestaw ten będzie świetnie brzmiał.",
                        Category = "Perkusje",
                        Price = 2570M
                    },
                    new Product
                    {
                        Name = "Nord Stage 3 88 - Stage Piano",
                        Description = "Stage Piano, klawiatura młoteczkowa 88 klawiszy, 3 moduły brzmieniowe, Piano [2GB pamięci, String Resonance], Organ [3 typy klasyków organowych, Drawbary, 2 manuały w multi], Synth [Nord Lead A1, sample 480MB], 2 ekrany OLED, sekcja efektów",
                        Category = "Syntezatory",
                        Price = 13325M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
