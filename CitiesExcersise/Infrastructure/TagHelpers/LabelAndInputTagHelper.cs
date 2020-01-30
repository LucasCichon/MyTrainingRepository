using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesExcersise.Infrastructure.TagHelpers
{
    [HtmlTargetElement("label",Attributes ="helper-for")]
    [HtmlTargetElement("input",Attributes ="helper-for")]
    
    public class LabelAndInputTagHelper : TagHelper
    {
        public ModelExpression HelperFor { get; set; } // wartością atrybutu helper-for jest właściwość z klasy Model, któa zostałą wykryta przez framework MVC i dostarczona atrybutowi pomocniczemu znacznika jako obiekt ModelExpression

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(output.TagName == "label")
            {
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.Append(HelperFor.Name);
                output.Attributes.SetAttribute("for", HelperFor.Name);
            }
            else if(output.TagName == "input")
            {
                output.TagMode = TagMode.SelfClosing;
                output.Attributes.SetAttribute("class", "form-control");
                output.Attributes.SetAttribute("name", HelperFor.Name);
                if(HelperFor.Metadata.ModelType == typeof(int?))
                {
                    output.Attributes.SetAttribute("type", "number");
                }
            }
        }

    }
}
