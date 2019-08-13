using System;
using Lib.Data.Models;

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

    public PostReplyViewModel() { }

    public PostReplyViewModel(
      PostReply replyDb,
      ApplicationUser userDb,
      Post postDb)
    {
      this.Id = replyDb.Id;
      this.Content = replyDb.Content;
      this.CreatedAt = replyDb.CreatedAt;
      this.AuthorId = userDb.Id;
      this.AuthorName = userDb.UserName;
      this.AuthorRating = userDb.Rating;
      this.AuthorImageUrl = userDb.ProfileImageUrl;
      this.PostId = postDb.Id;
    }
  }
}