namespace ImpApi.Models
{
  public class Save
  {
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    public int UserId { get; set; }
    public User? User { get; set;}
    public DateTime Date { get; set; }
    
  }
}