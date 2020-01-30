using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextDelegate;

        public ErrorMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);

            if(httpContext.Response.StatusCode == 403)  //response - reakcja, odpowiedź   StatusCode - kod stanu
            {
                await httpContext.Response
                    .WriteAsync("Przeglądarka WWW Microsoft Edge jest nieobsługiwana.", Encoding.UTF8);
            }
            else if(httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                    .WriteAsync("Brak treści.", Encoding.UTF8);
            }
        }
    }
}
