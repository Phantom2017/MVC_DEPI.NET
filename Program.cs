using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Day1.Models;

namespace MVC_Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Builder pattern
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddResponseCaching();
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
            {
                op.Password.RequireNonAlphanumeric=true;
                op.Password.RequiredLength = 8;                
            }).AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddSession(t =>
            {
                t.IdleTimeout= TimeSpan.FromDays(1);
            });

            var app = builder.Build();

            app.UseResponseCaching();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "FourSegment",
            //    pattern: "AdminSite/{action}/{name:alpha}/{age:int}"
            //    );

            //Add Roles to DB
            var scope=app.Services.CreateScope();
            var roleMgr= scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (roleMgr.Roles.Count()==0)
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("Moderator"),
                    new IdentityRole("User")
                };

                foreach (var role in roles)
                {
                    roleMgr.CreateAsync(role).Wait();
                }
            }

            app.Run();

            //Types of middleware:
            //(1) write ---> call next  (use)
            //(2) write --->terminate  (run)
            //(3) map
        }
    }
}
