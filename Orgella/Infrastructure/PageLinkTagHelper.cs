using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Orgella.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgella.Infrastructure
{
    [HtmlTargetElement("div",Attributes ="page-model")]
    public class PageLinkTagHelper : TagHelper //klasa dziedziczy po klasie bazowej TagHelper która zwraca metode Process
    {
        private IUrlHelperFactory urlHelperFactory; // obiekt potrebny to zwrócenia instancji obiektu IUrlHelper
        public PageLinkTagHelper(IUrlHelperFactory url) => urlHelperFactory = url;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definiuje kontrakt dla pomocnika na tworzenie adresów URL dla ASP.NET MVC w aplikacji.
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); //GetUrlHelper - zwraca żądania związane z kontextem
            TagBuilder result  = new TagBuilder("div");
            for(int i=1; i<=PageModel.TotalPages(); i++)
            {
                TagBuilder tag = new TagBuilder("a");
                //tagowi href pszypisujemy nazwę akcji z widoku (u nas List) oraz przekazujemy jej parametr(metoda List przyjmuje parametr int do określenia strony)
                tag.Attributes["href"] = urlHelper.Action(PageAction, // metodzie action przekazujemy 2 parametry. nazwę akcji do wykonania oraz obiekt
                    new { productPage = i });
                //
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }


    }
}
