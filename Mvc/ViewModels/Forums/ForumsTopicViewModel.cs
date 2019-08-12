using System.Collections.Generic;

namespace Mvc.ViewModels.Forums
{
  public class ForumsTopicViewModel
  {
    public ForumViewModel Forum { get; set; }
    public IEnumerable<PostViewModel> Posts { get; set; }
  }
}