using System.Collections.Generic;
using System.Linq;
using Lib.Data.Models;

namespace Mvc.ViewModels
{
  public class ForumViewModel
  {
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public IEnumerable<PostViewModel> Posts { get; set; }

    public ForumViewModel() { }

    public ForumViewModel(Forum forumDb)
    {
      this.Id = forumDb.Id;
      this.Title = forumDb.Title;
      this.Description = forumDb.Description;
      this.ImageUrl = forumDb.ImageUrl;
    }

    public ForumViewModel(Forum forumDb, IEnumerable<Post> postsDb)
    {
      this.Id = forumDb.Id;
      this.Title = forumDb.Title;
      this.Description = forumDb.Description;
      this.ImageUrl = forumDb.ImageUrl;
      this.Posts = postsDb.Select(post => new PostViewModel(post));
    }
  }
}