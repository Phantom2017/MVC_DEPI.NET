using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;
using System.Diagnostics;

namespace MVC_Day1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Action
        public IActionResult Index()
        {
            return View();
        }

        //Action or endpoint
        //Public
        //can't be static
        //can't be overloaded
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ContentResult SayHello()
        {
            return Content("Hello World");
        }

        //Content   ContentResult
        //View      ViewResult
        //json      JsonResult
        //file      FileResult
        //empty
        //NotFound

        public ViewResult ShowView()
        { 
            //Declare
            ViewResult result = new ViewResult();

            //set
            result.ViewName = "MyView";

            //return
            return result;
        }

        public IActionResult ViewStudent(int stdId,string name)
        {
            if (stdId == 10)
            {
                return View("MyView");
            }
            else
            {
                return View("NotFound");
            }
        }

        //private ViewResult GetView(string viewName)
        //{
        //    //Declare
        //    ViewResult result = new ViewResult();

        //    //set
        //    result.ViewName = viewName;

        //    //return
        //    return result;
        //}
    }
}
