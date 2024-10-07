using Microsoft.AspNetCore.Identity;

namespace MVC_Day1.Models
{
    public class AppUser:IdentityUser
    {
        public Employee? Employee { get; set; }
        //public Manager? Manager { get; set; }
        public string Address { get; set; }
    }
}
