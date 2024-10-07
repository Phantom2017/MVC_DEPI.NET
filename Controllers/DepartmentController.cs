using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MVC_Day1.Models;

namespace MVC_Day1.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        DataContext context=new DataContext();
        private readonly IMemoryCache memoryCache;

        public DepartmentController(IMemoryCache memoryCache)  //Dependency Injection
        {
            this.memoryCache = memoryCache;
        }
        [Authorize]
        public IActionResult Index()
        {
            string cachKey = "DeptsCopy";

            if (!memoryCache.TryGetValue(cachKey,out List<Department> depts))
            {
                depts=context.Departments.ToList();

                var options = new MemoryCacheEntryOptions();
                options.SlidingExpiration = TimeSpan.FromMinutes(5); ;
                options.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);

                memoryCache.Set(cachKey, depts,options);
            }
            
            return View(depts);
        }

        //Display empty form
        //[Authorize]
        [MyErrorFilter]
        [Authorize(Roles ="Admin,Moderator")]
        public IActionResult NewDept()
        {
            //var claim= User.Claims.Where(c => c.Type == "age").FirstOrDefault();
            //claim.Value
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

        [ResponseCache(Duration =60,VaryByQueryKeys =["id"],Location = ResponseCacheLocation.Any)]
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
