using Microsoft.AspNetCore.Identity;

namespace Backend_Project.Entities
{
    public class CustomUser:IdentityUser
    {
        public string Fullname { get; set; } = null!;
    }
}
