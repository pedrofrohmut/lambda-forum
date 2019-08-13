using System.Collections.Generic;

namespace Mvc.ViewModels.Home
{
  public class HomeIndexViewModel
  {
    public IEnumerable<PostViewModel> LatestPosts { get; set; }
    public string SearchQuery { get; set; } = "";
  }
}