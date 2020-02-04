using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Models
{
    public class SeedDataPromotion
    {
        public static ApplicationDbContext ApplicationServices { get; private set; }

        public static void EnsurePopulate(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Products.Where(p => p.OldPrice == null).Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Fletnia Pana",
                        Description = "Składa się z szeregu drewnianych piszczałek, ułożonych w jednym lub dwóch rzędach. Dźwięki wydobywa się poprzez dmuchanie w krawędzie otworów piszczałek. Piszczałki wykonywano pierwotnie z pustych łodyg trzciny(por.mit o Syrinks).Materiały obecnie stosowane do produkcji tego instrumentu to: bambus, drewno klonowe(klon jawor), drewno z niektórych gatunków drzew owocowych – np.śliwy, gruszy, czereśni, a także szkło itp.",
                        Category = "Instrumenty Drewniane",
                        Price = 1999M,
                        OldPrice = 2500M
                    },
                    new Product
                    {
                        Name = "Boss GT-100",
                        Description = "Z nowym uaktualnieniem GT-100 Wersja 2.0, flagowy procesor multiefektowy BOSS jest jeszcze bardziej potężny niż wcześniej, dodając zestaw świetnych możliwości do jego już bogatego arsenału. Zawarto dwa nowe typy wzmacniaczy wraz z świetnymi efektami MDP, akustyczny symulator oraz ulepszony efekt rotary. Na pokładzie znalazła się też przydatna funkcja Guitar-to-MIDI, która pozwala czerpać z dobrodziejstw programu Guitar Friend Jam i innych na komputerze przy użyciu normalnej gitary. Możliwości USB w GT-100 także zostały rozszerzone, dając większą elastyczność przy re-ampingu. Dzięki programowi BOSS TONE STUDIO możesz teraz edytować brzmienia GT-100 w przyjaznym środowisku graficznym na komputerze. ",
                        Category = "Efekty Gitarowe",
                        Price = 890M,
                        OldPrice=1300M
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
