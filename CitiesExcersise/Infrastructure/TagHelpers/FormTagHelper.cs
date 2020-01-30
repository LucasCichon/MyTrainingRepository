using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesExcersise.Infrastructure.TagHelpers
{
    public class FormTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public FormTagHelper(IUrlHelperFactory factory) => urlHelperFactory = factory;

        [ViewContext]
        [HtmlAttributeNotBound]
        //klasa ViewContext dostarcza szczegółowe informacje dotyczące generowania widoku, danych routingu oraz aktualnego żądania HTTP
        public ViewContext ViewContextData { get; set; } 

        public string controller { get; set; }
        public string Action { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContextData); // pobranie obiektu url. Obiekt jest skonfigurowany za pomocą obiektu ViewContext, a następnie używany do utworzenia adresu URL dla atrybutu action elementu wyjściowego.

            //ustawiamy atrybut action na nazwe metody pobranej z adresu url albo z rulHelper, a jeżeli nie istnieje to z ViewContextData...
            //jakoś tak :P
            output.Attributes.SetAttribute("action", urlHelper.Action(Action ?? ViewContextData.RouteData.Values["action"].ToString(),
                ViewContextData.RouteData.Values["controller"].ToString()));
        }
    }
}
