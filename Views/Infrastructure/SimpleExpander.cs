using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach(String location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
            yield return "View/Legacy/{1}/{0}/View.schtml";
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //tutaj nie robimy narazie nic
        }
    }
}
