using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_Day1.Models
{
    public class DataContext:IdentityDbContext<AppUser>//DbContext
    {
        public DataContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Everytime
            optionsBuilder.UseSqlServer("Data Source=.\\sql19;Initial Catalog=DEPI.NET;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<Department>().HasData(new Department { DeptID = 1, Name = "SD", ManagerName = "Ahmed Salah" });
            modelBuilder.Entity<Department>().HasData(new Department { DeptID = 2, Name = "Hr", ManagerName = "Asmaa Mohamed" });
            modelBuilder.Entity<Department>().HasData(new Department { DeptID = 3, Name = "Finance", ManagerName = "Ali Essam" });

            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, Name = "Amany Farouk", Salary = 3500, Address = "Assiut", Img = "f.jpg", deptId = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, Name = "Amira Ahmed", Salary = 4000, Address = "Assiut", Img = "f.jpg", deptId = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 3, Name = "Abanoub Gaber", Salary = 5000, Address = "Assiut", Img = "m.jpg", deptId = 3 });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 4, Name = "Amir Mostafa", Salary = 4000, Address = "Assiut", Img = "m.jpg", deptId = 2 });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
