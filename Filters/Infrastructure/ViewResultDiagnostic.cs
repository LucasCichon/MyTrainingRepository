using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class ViewResultDiagnostic : IActionFilter
    {
        private IFilterDiagnostic diagnostics;
        public ViewResultDiagnostic(IFilterDiagnostic diag)
        {
            diagnostics = diag;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult vr;
            if((vr = context.Result as ViewResult) != null)
            {
                diagnostics.AddMessage($"Nazwa widoku: {vr.ViewName}.");
                diagnostics.AddMessage($"Typ modelu: {vr.ViewData.Model.GetType().Name}.");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
        }
    }
}
