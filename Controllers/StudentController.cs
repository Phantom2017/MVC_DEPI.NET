using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;

namespace MVC_Day1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudents()
        {
            StudentBL model = new StudentBL();

            var students = model.getAll();

            //return View("myView",students);
            return View(students);
        }

        public IActionResult GetById(int id)
        {
            StudentBL students = new StudentBL();

            var student =students.getById(id);

            return View("GetStudent",student);
        }
    }
}
