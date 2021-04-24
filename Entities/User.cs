using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Entities
{
    public class User : IdentityUser<int>
    {
    
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
