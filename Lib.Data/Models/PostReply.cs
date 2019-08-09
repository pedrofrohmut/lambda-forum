using System;

namespace Lib.Data.Models
{
  public class PostReply
  {
    public string Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual Post Post { get; set; }
  }
}