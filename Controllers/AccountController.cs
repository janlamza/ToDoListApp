using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Entities;
using ToDoApp.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;


        public AccountController(UserManager<User> userManager, RoleManager<AppRole> roleManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await userExists(registerDto.Username)) return BadRequest("Username is taken!");

            User user = new User
            {
                UserName = registerDto.Username,
            };


            var result = await _userManager.CreateAsync(user, registerDto.password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        [HttpDelete("delete")]
         public async Task<IActionResult> Delete(DeleteDto deleteDto)
        {
            var userToDelete = await _userManager.Users.FirstOrDefaultAsync(c => c.UserName == deleteDto.Username);

            var result = await _userManager.DeleteAsync(userToDelete);
            if (result.Succeeded) return Ok();
            else return BadRequest("wasnt able to delete user");
        }




        public async Task<bool> userExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username);
        }

    }
}
