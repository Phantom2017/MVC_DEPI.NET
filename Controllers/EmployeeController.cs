using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;
using MVC_Day1.ViewModels;

namespace MVC_Day1.Controllers
{
    public class EmployeeController : Controller
    {
        public DataContext context=new DataContext();
        public IActionResult Index()
        {
            var emps=context.Employees.ToList();
            var depts=context.Departments.Select(d=>d.Name).ToArray();

            //Using ViewData
            ViewData["depts"] = depts;
            ViewData["num"] = 5;
            ViewData["date"]=DateTime.Now;

            //Using ViewBag

            ViewBag.names = depts;
            return View(emps);
        }


        public IActionResult EmpCard(int id)
        {
            var emp = context.Employees.Find(id);

            var vm = new EmpCardVM
            {
                Id = emp.Id, Name = emp.Name, Address = emp.Address, Img = emp.Img
            };

            return View(vm);
        }
    }
}
