using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class DiagnosticFilter : IAsyncResultFilter
    {
        private IFilterDiagnostic diagnostic;
        public DiagnosticFilter(IFilterDiagnostic diag)
        {
            diagnostic = diag;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            foreach(string message in diagnostic?.Message)
            {
                byte[] bytes = Encoding.ASCII.GetBytes($"<div>{message}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }
    }
}
