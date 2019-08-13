using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Data.Models;

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

    public PostViewModel() { }

    public PostViewModel(
      Post postDb,
      ApplicationUser userDb,
      IEnumerable<PostReply> repliesDb)
    {
      this.Id = postDb.Id;
      this.Title = postDb.Title;
      this.Content = postDb.Content;
      this.CreatedAt = postDb.CreatedAt;
      this.AuthorId = userDb.Id;
      this.AuthorName = userDb.UserName;
      this.AuthorRating = userDb.Rating;
      this.PostRepliesCount = repliesDb.Count();
    }
  }
}