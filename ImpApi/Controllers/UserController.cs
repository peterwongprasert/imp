using Microsoft.AspNetCore.Mvc;
using ImpApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImpApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
      _context = context;
    }

    // [HttpPost("login")]
    // public async Task<ActionResult<User>> Login([FromBody] User userModel)
    // {
    //   var user = await _context.User
    //     .FirstOrDefaultAsync(u => u.Email == userModel.Email && u.Password == userModel.Password);

    //     if(user == null)
    //     {
    //       return NotFound("user not found or incorrect password");
    //     }

    //     return user;
    //   // return await _context.User.ToListAsync();
    // }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login([FromBody] LoginDto loginDto)
    {
      var user = await _context.User
        .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

       if(user == null)
       {
        return NotFound("User not found or incorrect password");
       } 

       var userDto = new UserDto
       {
        Id = user.Id,
        Name = user.Name,
        ProfilePic = user.ProfilePicture
       };

       return Ok(userDto);
    }
  }
}