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
    [HtmlTargetElement("div", Attributes ="admin-page-model")]
    public class AdminPageLinkTagHelper : TagHelper
    {
        //To jest potrzebne żeby uzyskać obiekt UrlHelper
        IUrlHelperFactory urlHelperFactory;
        public AdminPageLinkTagHelper(IUrlHelperFactory url) => urlHelperFactory = url; 


        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        
        public PagingInfo AdminPageModel { get; set; } // nazwa zmiennej muzi być taka sama jak Attributes !!!!
        public string AdminPageAction { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper UrlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            for(int i=1; i<=AdminPageModel.TotalPages(); i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = UrlHelper.Action(AdminPageAction,
                    new { AdminPage = i });
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);

        }
    }
}
