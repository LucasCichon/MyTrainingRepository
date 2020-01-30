using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware  //oprogramowanie pośredniczące
    {
        //obiekt typu RequestDelegate przedstawia następny komponent oprogramowania pośredniczącego w łańcuchu
        private RequestDelegate nextDelegate;   //request - żądanie
        private UptimeService uptime;

        public ContentMiddleware(UptimeService up, RequestDelegate next)
        {
            nextDelegate = next;
            uptime = up;

        }
        //metoda wywoływana gdy platforma ASP.NET otrzymuje żądanie HTTP
        public async Task Invoke(HttpContext httpContext)   //Invoke - odwoływać sie do czegoś, powoływac się na coś
        {
            if(httpContext.Request.Path.ToString().ToLower() == "/middleware") //Request - żądanie
            {
                await httpContext.Response.WriteAsync(
                    "Ten komunikat pochodzi z oprogramowania pośredniczącego:"+$"(uptime: {uptime.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
