using CitiesExcersise.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CitiesExcersise.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes ="model-for")]
    public class SelectOptionTagHelper : TagHelper
    {
        private IRepository repository;
        public SelectOptionTagHelper(IRepository repo) => repository = repo;

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync(false)).GetContent());

            string selected = ModelFor.Model as string;

            PropertyInfo property = typeof(City).GetTypeInfo().GetDeclaredProperty(ModelFor.Name); //PropertyInfo - instancja klasy abstrakcyjnej PropertyInfo
            foreach (string country in repository.Cities.Select(c => c.Country).Distinct())
            {
                if(selected != null && selected.Equals(country, StringComparison.OrdinalIgnoreCase))
                {
                    output.Content.AppendHtml($"<option selected>{country}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option>{country}</option>");
                }
            }
            output.Attributes.SetAttribute("Name", ModelFor.Name);
            output.Attributes.SetAttribute("Id", ModelFor.Name);
        }
    }
}
