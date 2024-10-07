using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;
using MVC_Day1.ViewModels;
using System.Security.Claims;

namespace MVC_Day1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        //Login
        //Logout
        //Register

        //Dependency Injection to add usermanager
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName=vm.Username;
                appUser.Address=vm.Address;

                IdentityResult result= await userManager.CreateAsync(appUser,vm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "User");
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                var appUser= await userManager.FindByNameAsync(vm.Username);
                if (appUser!=null)
                {
                    if (await userManager.CheckPasswordAsync(appUser, vm.Password))
                    {
                        var claims= new List<Claim>
                        {
                            new Claim("age", "34")
                        };

                        await signInManager.SignInWithClaimsAsync(appUser, true, claims);
                        await signInManager.SignInAsync(appUser,true);
                        return RedirectToAction("Index", "Department");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong data");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong data");
                }
            }
            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
