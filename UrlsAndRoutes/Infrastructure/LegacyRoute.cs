using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        private string[] urls;
        private IRouter mvcRouter;

        public LegacyRoute(IServiceProvider services, params string [] targetUrls)
        {
            this.urls = targetUrls;
            mvcRouter = services.GetRequiredService<MvcRouteHandler>();
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }
            return null;   
        }

        public async Task RouteAsync(RouteContext context)
        {
            string requestUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (urls.Contains(requestUrl, StringComparer.OrdinalIgnoreCase))
            {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestUrl;
                await mvcRouter.RouteAsync(context);
            }
        }
    }
}
