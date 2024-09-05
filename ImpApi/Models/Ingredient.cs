namespace ImpApi.Models
{
  public class Ingredient
  {
    public Ingredient(string name)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      RecipeIngredient = new List<RecipeIngredient>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredient { get; set; }
  }
}