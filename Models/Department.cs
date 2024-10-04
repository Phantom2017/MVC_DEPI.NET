using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day1.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; } //Identity auto increment from 1 -->
        [MaxLength(100)]
        [ValidateDeptName]
        public string Name { get; set; }
        [Remote("MaxFive","Department",ErrorMessage ="Name must be less than 5")]
        public string ManagerName { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
