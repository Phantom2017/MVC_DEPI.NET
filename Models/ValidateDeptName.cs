using System.ComponentModel.DataAnnotations;

namespace MVC_Day1.Models
{
    public class ValidateDeptName:ValidationAttribute
    {
        DataContext dataContext=new DataContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string deptName=(string)value;

            var result =dataContext.Departments.Any(d=>d.Name==deptName);

            if(!result) 
                return ValidationResult.Success;
            return new ValidationResult("Sorry this name is taken");
        }
    }
}
