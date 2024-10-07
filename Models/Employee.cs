using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(100,MinimumLength =10)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(5000,10000)]
        public int Salary { get; set; }
        [Display(Name ="User Image")]
        public string Img { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; } = "ABC";
        public AppUser AppUser { get; set; }
        //[DataType(DataType.Password)]
        //[CreditCard]
        //[EmailAddress]
        //[Url]
        //public string Password { get; set; }
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }
    }
}
