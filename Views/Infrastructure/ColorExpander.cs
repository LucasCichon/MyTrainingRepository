using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class ColorExpander : IViewLocationExpander
    {
        private static Dictionary<string, string> Colors = new Dictionary<string, string>
        {
            ["red"] = "Red",
            ["green"] = "Green",
            ["blue"] = "Blue"
        };


        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //Metoda używa obiektu ActionContext w celu pobrania danych routingu i szuka wartośći segmentu id adresu URL. Jeżeli ten segment istnieje i ma wartość reg, grees lub blue, wówczas wkspander widoku dodaje do słownika Calues właściwoś o nazwie color. To jest proces karegoryzacji: żądania o segmencie id dopadsowanym do koloru są kategoryzowane za pomocą słowa kluczowego color, o wartości odpowiadającej wartości segmentu.
            var routeValues = context.ActionContext.RouteData.Values; // ActionContext - zwraca obiekt opisujący metodę akcji, która zażądała widoku, a także zawiera informacje szczegółowe dotyczące żądania i odpowiedzi na nie.
            
            string color;
            if(routeValues.ContainsKey("id") //jeżeli dane routingu zawierają element id
                && Colors.TryGetValue(routeValues["id"] as string, out color) // i jeżeli w kolekcji Colors znajduje się element o takim kluczu, wtedy przypisz go do zmiennej color
                && !string.IsNullOrEmpty(color)) //i sprawdz zmienną color czy nie jest pusta
            {
                context.Values["color"] = color;    // ?? context.Values - ta włąściwość zwraca obiekt typu IDictionary<string,string>, do którego ekspander widoku dodaje pary klucz-wartość unikatowo identyfikujące kategorię żądania. 
            }
        }

        //Następnie silnik Razor wywołuje metodę ExpandViewLocations() i dostarcza ten sam obiekt kontekstu, który wcześniej zostąłużyty przez metodę PopulateValues(). Dzięki temu ekspander widoku może przeanalizowaź przugotowane wcześniej dane o kategoriach i wygenerować zbiór miejs, które powinny zostać sprawdzone podczas szukania widoku. W oawianym przukadzie użyłem metody string.Replace() do zastąpienia miejsca zarezerwowanego {0} nazwą koloru.
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            string color;   //inicjujemy zmienną string
            context.Values.TryGetValue("color", out color);     // sprawdzamy czy w słodniku Dictionary jest wartość o kluczu "color", jeżeli jest, przypisujemy ją zmiennej color

            foreach(string location in viewLocations)
            {
                if (!string.IsNullOrEmpty(color))   //jeżeli  zmienna color nie jest pusta
                {
                    yield return location.Replace("{0}", color);    //zamieniamy {"0"} na wartość zmiennej color
                }
                else
                {
                    yield return location;  
                }
            }
        }
    }
}
