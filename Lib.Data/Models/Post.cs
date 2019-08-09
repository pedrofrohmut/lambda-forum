using System;
using System.Collections.Generic;

namespace Lib.Data.Models
{
  public class Post
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual Forum Forum { get; set; }

    public virtual IEnumerable<PostReply> PostReplies { get; set; }
  }
}