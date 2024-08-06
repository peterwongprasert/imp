using Microsoft.EntityFrameworkCore;

namespace ImpApi.Models
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }

    public DbSet<User> User { get; set; }
  }
}