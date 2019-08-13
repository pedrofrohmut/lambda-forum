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
    public int PostRepliesCount { get; set; }

    public ApplicationUserViewModel Author { get; set; }
    public string AuthorId { get; set; }
    public IEnumerable<PostReplyViewModel> Replies { get; set; }
    public ForumViewModel Forum { get; set; }
    public string ForumId { get; set; }

    public PostViewModel() { }

    public PostViewModel(Post postDb)
    {
      this.Id = postDb.Id;
      this.Title = postDb.Title;
      this.Content = postDb.Content;
      this.CreatedAt = postDb.CreatedAt;
    }

    public PostViewModel(
      Post postDb,
      ApplicationUser userDb,
      IEnumerable<PostReply> repliesDb)
    {
      this.Id = postDb.Id;
      this.Title = postDb.Title;
      this.Content = postDb.Content;
      this.CreatedAt = postDb.CreatedAt;
      this.Author = new ApplicationUserViewModel(userDb);
      this.PostRepliesCount = repliesDb.Count();
    }

    public PostViewModel(
      Post postDb,
      ApplicationUser userDb,
      IEnumerable<PostReply> repliesDb,
      Forum forumDb)
    {
      this.Id = postDb.Id;
      this.Title = postDb.Title;
      this.Content = postDb.Content;
      this.CreatedAt = postDb.CreatedAt;
      this.Author = new ApplicationUserViewModel(userDb);
      this.PostRepliesCount = repliesDb.Count();
      this.Forum = new ForumViewModel(forumDb);
    }

    public Post GetModel(PostViewModel viewModel)
    {
      return new Post
      {
        Id = viewModel.Id,
        Title = viewModel.Title,
        Content = viewModel.Content,
        CreatedAt = DateTime.UtcNow,
      };
    }
  }
}