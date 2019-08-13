using System;
using Lib.Data.Models;

namespace Mvc.ViewModels
{
  public class PostReplyViewModel
  {
    public string Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public ApplicationUserViewModel Author { get; set; }

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
      this.Author = new ApplicationUserViewModel(userDb);
      this.PostId = postDb.Id;
    }
  }
}