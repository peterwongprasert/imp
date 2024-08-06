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
  public class PostController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PostController(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
      return await _context.Posts.ToListAsync();
    }

    [HttpGet("{postId}")]
    public async Task<ActionResult<Post>> GetPost(int postId)
    {
      var post = await _context.Posts.FindAsync(postId);

      if(post == null)
      {
        return NotFound();
      }

      return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> PostPost(Post post)
    {
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPost", new { id = post.PostId }, post);
    }

  [HttpPut("{postId}")]
    public async Task<IActionResult> PutPost(int postId, Post post)
    {
      if(postId != post.PostId)
      {
        return BadRequest();
      }

      _context.Entry(post).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!PostExists(postId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePost(int postId)
    {
      var post = await _context.Posts.FindAsync(postId);
      if(post == null)
      {
        return NotFound();
      }

      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool PostExists(int PostId)
    {
      return _context.Posts.Any(e =>e.PostId ==  PostId);
    }
  }

}