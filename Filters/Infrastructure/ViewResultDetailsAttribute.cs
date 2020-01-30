using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class ViewResultDetailsAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["Typ wyniku"] = context.Result.GetType().Name,
            };
            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null)
            {
                dict["Nazwa widoku"] = vr.ViewName;
                dict["Typ modelu"] = vr.ViewData.Model.GetType().Name;
                dict["Dane modelu"] = vr.ViewData.Model.ToString();
            }

            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                { Model = dict }
            };
            await next();
        }
    }
}
