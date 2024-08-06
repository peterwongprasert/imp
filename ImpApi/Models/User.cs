using System.Security.Cryptography.Xml;

namespace ImpApi.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public int UserType { get; set; }
    public DateTime Joined { get; set; }

    // Reference to recipe table 
    // use ICollection if you have a lot of something
    public ICollection<Recipe> Recipes { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Save> Saves { get; set; }
  }
}