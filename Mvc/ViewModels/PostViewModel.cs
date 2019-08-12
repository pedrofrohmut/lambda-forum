using System;

namespace Mvc.ViewModels
{
  public class PostViewModel
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public string AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int AuthorRating { get; set; }

    public int PostRepliesCount { get; set; }
  }
}