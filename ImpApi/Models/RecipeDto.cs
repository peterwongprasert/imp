namespace ImpApi.Models
{
  public class RecipeDto
  {
      public int Id { get; set; }
      public required string Name { get; set; }
      public string Description { get; set; }
      public string Image { get; set; }
      public int UserId { get; set; }
      public DateTime Date { get; set; }
      public required string ProfilePicture { get; set; } // User's image
      public required string UserName { get; set; }
  }
}