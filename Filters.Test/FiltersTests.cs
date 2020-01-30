using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Filters.Infrastructure;

namespace Filters.Test
{
    public class FiltersTests 
    {
        [Fact]
        public void TestHttpsFilter()
        {
            //Przygotowanie.
            var httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(m => m.IsHttps).Returns(true).Returns(false);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpRequest.Object);

            var actionContext = new ActionContext(httpContext.Object, new Microsoft.AspNetCore.Routing.RouteData(), new ActionDescriptor());
            var authContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());

            HttpsOnlyAttribute filter = new HttpsOnlyAttribute();

            //Działanie i asercje.
            filter.OnAuthorization(authContext);
            Assert.Null(authContext.Result);

            filter.OnAuthorization(authContext);
            Assert.IsType(typeof(StatusCodeResult), authContext.Result);
            Assert.Equal(StatusCodes.Status403Forbidden, (authContext.Result as StatusCodeResult).StatusCode);
        }
    }
}
