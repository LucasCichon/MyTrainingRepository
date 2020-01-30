using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Xunit;

namespace Cities.Tests
{
    public class TagHelperTests
    {
        [Fact]
        public void TestTagHelper()
        {
            //Przygotowanie.
            var context = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                "myuniqueid");
            var output = new TagHelperOutput("button",
                new TagHelperAttributeList(), (cache, Encoder) =>
                Task.FromResult<TagHelperContent>
                (new DefaultTagHelperContent()));
            //Działanie.
            var tagHelper = new ButtonTagHelper
            {
                BsButtonColor = "wartośćTestowa"
            };
            tagHelper.Process(context, output);
            //Asercje.
            Assert.Equal($"btn btn-{tagHelper.BsButtonColor}",
                output.Attributes["class"].Value);
        }
    }
}
