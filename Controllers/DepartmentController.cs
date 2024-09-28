using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;

namespace MVC_Day1.Controllers
{
    public class DepartmentController : Controller
    {
        DataContext context=new DataContext();
        public IActionResult Index()
        {
            var depts=context.Departments.ToList();
            return View(depts);
        }

        //Display empty form
        public IActionResult NewDept()
        {
            return View(new Department());        
        }

        //Save data
        [HttpPost]
        public IActionResult NewDept(Department dept)
        {
            if (dept.Name!=null)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(dept);
            
        }
    }
}
