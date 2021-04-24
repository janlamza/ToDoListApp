using Microsoft.AspNetCore.Identity;

namespace ToDoApp.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public User user { get; set; }
        public AppRole Role { get; set; }
    }
}