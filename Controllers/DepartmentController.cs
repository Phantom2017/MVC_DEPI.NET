using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;

namespace MVC_Day1.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        DataContext context=new DataContext();
        public IActionResult Index()
        {
            var depts=context.Departments.ToList();
            return View(depts);
        }

        //Display empty form
        //[Authorize]
        [MyErrorFilter]
        public IActionResult NewDept()
        {
            return View(new Department());        
        }

        //Save data
        [HttpPost]
        public IActionResult NewDept(Department dept)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(dept);
            
        }

        public IActionResult ViewEmps()
        {
            var depts = context.Departments.ToList();
            ViewData["depts"] = depts;
            return View();
        }

        public IActionResult getEmps(int id)
        {
            var emps=context.Employees.Where(e=>e.deptId==id).ToList();

            return PartialView(emps);
        }

        public JsonResult MaxFive(string ManagerName)
        {
            return Json(ManagerName.Length <= 5);
        }
    }
}
