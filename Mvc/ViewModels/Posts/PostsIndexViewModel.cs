using System.Collections.Generic;

namespace Mvc.ViewModels.Posts
{
  public class PostsIndexViewModel
  {
    public PostViewModel Post { get; set; }
    public IEnumerable<PostReplyViewModel> PostReplies { get; set; }
  }
}