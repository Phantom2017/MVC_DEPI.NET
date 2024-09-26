using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string Img { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        public Department Department { get; set; }
    }
}
