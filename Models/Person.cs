using Microsoft.AspNetCore.Identity;

namespace ResumeGenerator.Models
{
    public class Person:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
