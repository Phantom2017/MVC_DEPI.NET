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

        public IActionResult SaveData(int id,Employee employee)
        {
            //get ---> url
            //post ---> request body

            //Model Binding
            //Request.Form
            //Request.RouteValues
            //Request.QueryString
            //Default

            //Dict/List  --> dict[ahmed]=123&dict[adel]=345

            //Complex object
            //Employee
            return View();
        }

        public IActionResult EditEmp(int id) 
        {
            var emp = context.Employees.Find(id);
            ViewData["depts"]=context.Departments.ToList();
            return View(emp);
        }

        [HttpPost]
        public IActionResult EditEmp(Employee newEmp)
        {
            var oldEmp = context.Employees.Find(newEmp.Id);
            if (ModelState.IsValid)
            {
                oldEmp.Name = newEmp.Name;
                oldEmp.Address = newEmp.Address;
                oldEmp.Img = newEmp.Img;
                oldEmp.Salary = newEmp.Salary;
                oldEmp.deptId = newEmp.deptId;

                context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewData["depts"] = context.Departments.ToList();
                return View(newEmp);
            }
        }

        public IActionResult DeleteEmp(int id)
        {
            var emp = context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult DeleteEmp(Employee emp)
        {
            var delEmp = context.Employees.Find(emp.Id);
            context.Remove(delEmp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult EmpPartial(int id)
        {
            var emp=context.Employees.Find(id);

            return View("_EmpPartial",emp);
        }
    }
}
