using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lib.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using Mvc.ViewModels.Home;

namespace Mvc.Controllers
{
  [Route("home")]
  public class HomeController : Controller
  {
    private readonly IPosts postsService;

    public HomeController(IPosts postsService)
    {
      this.postsService = postsService;
    }

    [HttpGet("index")]
    public async Task<ActionResult> Index()
    {
      var latestPostsDb = await this.postsService.GetLatestPosts(10);
      var latestPosts = latestPostsDb.Select(post =>
        new PostViewModel(post, post.ApplicationUser, post.PostReplies, post.Forum));
      var model = new HomeIndexViewModel
      {
        SearchQuery = "",
        LatestPosts = latestPosts,
      };
      return View(model);
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
