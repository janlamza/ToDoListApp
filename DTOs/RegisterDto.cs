using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.DTOs
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }
        [Required] public string password { get; set; }
    }
}
