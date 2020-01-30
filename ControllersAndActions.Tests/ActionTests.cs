using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        //    [Fact]
        //    public void ViewSelected()
        //    {
        //        //Przygotowanie.
        //        HomeController controller = new HomeController();

        //        //Działanie.
        //        ViewResult result = controller.ReceiveForm("Adam", "Londyn");

        //        //Assercje.
        //        Assert.Equal("Result", result.ViewName);
        //    }

        //[Fact]
        //public void ModelObjectType()
        //{
        //    //Przygotowanie.
        //    ExampleController controller = new ExampleController();
        //    //Działanie.
        //    ViewResult result = controller.Index();
        //    //Asercje.
        //    Assert.IsType<System.DateTime>(result.ViewData.Model);
        //}

        //[Fact]
        //public void ModelObjectType()
        //{
        //    //Przygotowanie.
        //    ExampleController controller = new ExampleController();
        //    //Działanie.
        //    ViewResult result = controller.Index();
        //    //Asercje.
        //    Assert.IsType<string>(result.ViewData["Message"]);
        //    Assert.Equal("Witaj", result.ViewData["Message"]);
        //    Assert.IsType<System.DateTime>(result.ViewData["Date"]);

        //}

        [Fact]
        public void Redirection()
        {
            //Przygotowanie.
            ExampleController controller = new ExampleController();
            //Działanie.
            RedirectToActionResult result = controller.Redirect();
            //Asercje.
            Assert.False(result.Permanent);
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Index", result.ActionName);
        }

        //[Fact]
        //public void Redirection()
        //{
        //    //Przygotowanie.
        //    ExampleController controller = new ExampleController();
        //    //Działanie.
        //    RedirectToRouteResult result = controller.Redirect();
        //    //Asercje.
        //    Assert.False(result.Permanent);
        //    Assert.Equal("Example", result.RouteValues["controller"]);
        //    Assert.Equal("Index", result.RouteValues["action"]);
        //    Assert.Equal("MyID", result.RouteValues["ID"]);
        //}

        //[Fact]
        //public void Redirection()
        //{
        //    //Przygotowanie.
        //    ExampleController controller = new ExampleController();
        //    //Działanie.
        //    RedirectResult result = controller.Redirect();
        //    //Asercje.
        //    Assert.Equal("/Example/Index", result.Url);
        //    Assert.True(result.Permanent);
        //}
        //[Fact]
        //public void JsonActionMethod()
        //{
        //    //Przygotowanie.
        //    ExampleController controller = new ExampleController();
        //    //Działanie.
        //    JsonResult result = controller.Index();
        //    //Asercje.
        //    Assert.Equal(new[] { "Alicja", "Bartek", "Janek" }, result.Value);
        //}
        [Fact]
        public void NotFoundActionMethod()
        {
            //Przygotowanie.
            ExampleController controller = new ExampleController();
            //Działanie.
            StatusCodeResult result = controller.NotFound();
            //Asercje.
            Assert.Equal(404, result.StatusCode);
        }
    }
}
