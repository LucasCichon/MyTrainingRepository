using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesExcersise.Infrastructure.TagHelpers
{
    [HtmlTargetElement("formbutton")]
    public class FormButtonTagHelper : TagHelper
    {
        public string Type { get; set; } = "Submita";
        public string BgColor { get; set; } = "primary";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", $"btn btn-{BgColor}");
            output.Attributes.SetAttribute("type", Type);
            output.Content.SetContent(Type == "submit" ? "Dodaj" : "Wyczyść");
        }
    }
}
