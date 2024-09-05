using System.Security.Cryptography.Xml;

namespace ImpApi.Models
{
  public class User
  {
    public User(string email, string password)
    {
      // for non-nullable properties define
      // make sure email and password are defined otherwise error message
      Email = email ?? throw new ArgumentNullException(nameof(email));
      // Name = name ?? throw new ArgumentNullException(nameof(name));
      Password = password ?? throw new ArgumentNullException(nameof(password));
      Recipes = new List<Recipe>();
      Likes = new List<Like>();
      Saves = new List<Save>();
    }

    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string? ProfilePicture { get; set; }
    public int UserType { get; set; }
    public DateTime Joined { get; set; }

    // Reference to recipe table 
    // use ICollection if you have a lot of something
    public ICollection<Recipe> Recipes { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Save> Saves { get; set; }
  }
}