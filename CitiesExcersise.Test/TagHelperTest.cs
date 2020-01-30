using Microsoft.AspNetCore.Razor.TagHelpers;
using CitiesExcersise.Infrastructure.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CitiesExcersise.Test
{
    public class TagHelperTest
    {
        [Fact]
        public void TestTagHelper()
        {
            //Przygotowanie.
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "myuniqueid");
            var output = new TagHelperOutput("button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            //Działanie.
            var tagHelper = new ButtonTagHelper
            {
                BsButtonColor = "wartośćTestowa"
            };
            tagHelper.Process(context, output);

            //Asercje.
            Assert.Equal($"btn btn-{tagHelper.BsButtonColor}", output.Attributes["class"].Value);

        }
    }
}
