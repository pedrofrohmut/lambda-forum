using System.Collections.Generic;

namespace Mvc.ViewModels.Forums
{
  public class ForumsIndexViewModel
  {
    public IEnumerable<ForumViewModel> Forums { get; set; }
  }
}