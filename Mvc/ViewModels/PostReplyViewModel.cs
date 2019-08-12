using System;

namespace Mvc.ViewModels
{
  public class PostReplyViewModel
  {
    public string Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public string AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int AuthorRating { get; set; }
    public string AuthorImageUrl { get; set; }

    public string PostId { get; set; }
  }
}