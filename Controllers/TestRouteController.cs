using Microsoft.AspNetCore.Mvc;

namespace MVC_Day1.Controllers
{
    public class TestRouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ContentResult DisplayData(string name,int age)
        {
            return Content("name= "+name+", Age= "+age);
        }
    }
}
