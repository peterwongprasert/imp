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
  public class RecipeController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public RecipeController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet("GetRecipes")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes(int currentPage, int postPerPage)
    {
      var recipes =  await _context.Recipe
        .Include(r => r.User) //join the user table
        .Select(r => new RecipeDto
        {
          Id = r.Id,
          Name = r.Name,
          Description = r.Description,
          Image = r.Image,
          UserId = r.UserId,
          Date = r.Date,
          ProfilePicture = r.User.ProfilePicture, // Fetch the user's image
          UserName = r.User.Name
        })
        .ToListAsync();

        foreach (var recipe in recipes)
        {
            Console.WriteLine($"Recipe Id: {recipe.Id}, Profile Picture: {recipe.ProfilePicture}");
        }
        
        return Ok(recipes);
    }
  }



}