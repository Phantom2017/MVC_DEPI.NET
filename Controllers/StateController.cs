using Microsoft.AspNetCore.Mvc;

namespace MVC_Day1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetCookies()
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("age", "50",options);
            return Content("Data saved");
        }

        public IActionResult GetCookies()
        {
            int age = int.Parse( Request.Cookies["age"]);
            return Content("Age is equal= " + age);
        }

        public ContentResult SetSession()
        {
            HttpContext.Session.SetString("key1", "Hello");
            HttpContext.Session.SetInt32("Age", 55);
            return Content("Data Saved");
        }

        public ContentResult GetSession() 
        {
            string key1= HttpContext.Session.GetString("key1");
            int age = HttpContext.Session.GetInt32("Age").Value;
            return Content("key= "+key1+", age= "+age);
        }
    }
}
