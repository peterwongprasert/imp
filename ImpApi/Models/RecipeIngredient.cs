namespace ImpApi.Models
{
  public class RecipeIngredient
  {
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }

    public int IngredientId { get; set; }
    public Ingredients Ingredient { get; set; }
  }
}