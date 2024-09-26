using System.ComponentModel.DataAnnotations;

namespace MVC_Day1.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; } //Identity auto increment from 1 -->
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
