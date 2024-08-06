

namespace ImpApi.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public User User { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set;}
    
    // like and save tables will be m:n like RecipeIngredients above
    public ICollection<Like> Likes { get; set; }
    public ICollection<Save> Saves { get; set; }
    public DateTime Date { get; set; }
  }
}