using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace ImpApi.Models
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // public DbSet<Post> Posts { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
    public DbSet<Like> Like { get; set; }
    public DbSet<Save> Save { get; set; }

        // linking keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // M:N relationship
            modelBuilder.Entity<RecipeIngredient>()
              .HasKey(ri => new { ri.RecipeId, ri.IngredientId});

            modelBuilder.Entity<RecipeIngredient>()
              .HasOne(ri => ri.Recipe)
              .WithMany(i => i.RecipeIngredient)
              .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
              .HasOne(ri => ri.Ingredient)
              .WithMany(i => i.RecipeIngredient)
              .HasForeignKey(i => i.IngredientId);
            
            // 1:M
            modelBuilder.Entity<Recipe>()
              .HasOne(r => r.User)
              .WithMany(u => u.Recipes)
              .HasForeignKey(r => r.UserId);

            
            // M:N
            modelBuilder.Entity<Like>()
              .HasKey(l => new { l.UserId, l.RecipeId });
            
            modelBuilder.Entity<Like>()
              .HasOne(l => l.User)
              .WithMany(l => l.Likes)
              .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Like>()
              .HasOne(l => l.Recipe)
              .WithMany(r => r.Likes)
              .HasForeignKey(l => l.RecipeId);

            modelBuilder.Entity<Save>()
              .HasKey(s => new { s.UserId, s.RecipeId });

            modelBuilder.Entity<Save>()
              .HasOne(s => s.User)
              .WithMany(u => u.Saves)
              .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Save>()
              .HasOne(s => s.Recipe)
              .WithMany(r => r.Saves)
              .HasForeignKey(s => s.RecipeId);
        }

        // Connect to mysql server 
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=localhost;Database=imp;User Id=root;");
        // }
    }
}