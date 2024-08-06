namespace ImpApi.Models
{
  public class Ingredients
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
  }
}