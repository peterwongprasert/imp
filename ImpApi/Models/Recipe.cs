

namespace ImpApi.Models
{
  public class Recipe
  {
    public Recipe(string name, string description, string image)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Description = description ?? throw new ArgumentNullException(nameof(name));
      Image = image ?? throw new ArgumentNullException(nameof(image));
      RecipeIngredient = new List<RecipeIngredient>();
      Likes = new List<Like>();
      Saves = new List<Save>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredient { get; set;}
    
    // like and save tables will be m:n like RecipeIngredients above
    public ICollection<Like> Likes { get; set; }
    public ICollection<Save> Saves { get; set; }
    public DateTime Date { get; set; }
  }
}