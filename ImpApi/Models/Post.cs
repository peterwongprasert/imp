using System.ComponentModel.DataAnnotations;

namespace ImpApi.Models
{

  public class Post
  {

    public int PostId { get; set;}
    public int UserId { get; set;}
    public string Image { get; set; }
    public string Description { get; set; }
  }
}