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

            builder.Services.AddSession(t =>
            {
                t.IdleTimeout= TimeSpan.FromDays(1);
            });

            var app = builder.Build();

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

            app.Run();

            //Types of middleware:
            //(1) write ---> call next  (use)
            //(2) write --->terminate  (run)
            //(3) map
        }
    }
}
