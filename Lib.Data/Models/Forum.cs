using System;
using System.Collections.Generic;

namespace Lib.Data.Models
{
  public class Forum
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ImageUrl { get; set; }

    // virtual for lazy loading
    public virtual IEnumerable<Post> Posts { get; set; }
  }
}