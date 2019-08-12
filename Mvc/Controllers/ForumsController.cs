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
      var forums = forumsDb.Select(forum =>
        new ForumViewModel
        {
          Id = forum.Id,
          Title = forum.Title,
          Description = forum.Description,
        });
      return View(new ForumsIndexViewModel { Forums = forums });
    }

    [HttpGet("topic/{id}")]
    public async Task<ActionResult> Topic(string id)
    {
      var forumDb = await this.forumsService.GetById(id);
      var forum =
        new ForumViewModel
        {
          Id = forumDb.Id,
          Title = forumDb.Title,
          Description = forumDb.Description,
          ImageUrl = forumDb.ImageUrl,
        };
      var posts = forumDb.Posts.Select(post =>
        new PostViewModel
        {
          Id = post.Id,
          Title = post.Title,
          AuthorName = post.ApplicationUser.UserName,
          AuthorRating = post.ApplicationUser.Rating,
          AuthorId = post.ApplicationUser.Id,
          DatePosted = post.CreatedAt,
          PostRepliesCount = post.PostReplies.Count(),
        });
      var model =
        new ForumsTopicViewModel
        {
          Forum = forum,
          Posts = posts,
        };
      return View(model);
    }
  }
}