using System.Linq;
using System.Threading.Tasks;
using Lib.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using Mvc.ViewModels.Forums;

namespace Mvc.Controllers
{
  [Route("forums")]
  public class ForumsController : Controller
  {
    private readonly IForums forumsService;
    private readonly IPosts postsService;

    public ForumsController(IForums forumsService, IPosts postsService)
    {
      this.forumsService = forumsService;
      this.postsService = postsService;
    }

    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
      var forumsDb = await this.forumsService.GetAll();
      var forums = forumsDb.Select(forum => new ForumViewModel(forum));
      return View(new ForumsIndexViewModel { Forums = forums });
    }

    [HttpGet("topic/{id}")]
    public async Task<ActionResult> Topic(string id)
    {
      var forumDb = await this.forumsService.GetById(id);
      var forum = new ForumViewModel(forumDb);
      var posts = forumDb.Posts.Select(post => new PostViewModel(post, post.ApplicationUser, post.PostReplies));
      var model = new ForumsTopicViewModel { Forum = forum, Posts = posts };
      return View(model);
    }
  }
}