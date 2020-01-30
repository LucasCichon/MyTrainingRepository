using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ControllersAndActions.Controllers
{   [Controller]
    //[NonController]
    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }    // włąściwość zdefiniowana w celu pobrania danych kontekstu

        //[NonAction]
        public ViewResult Index() => new ViewResult()
        {
            ViewName = "Result",
            ViewData = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
            {
                Model = $"To jest kontroler typu POCO."
            }
        };

        public ViewResult Headers() => new ViewResult()
        {
            ViewName = "DictionaryResult",
            ViewData = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary())
            {
                Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
            }
        };
    }
}
