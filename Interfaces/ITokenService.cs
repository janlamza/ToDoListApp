
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities;

namespace ToDoApp.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}