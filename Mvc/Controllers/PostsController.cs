using System.Linq;
using System.Threading.Tasks;
using Lib.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using Mvc.ViewModels.Posts;

namespace Mvc.Controllers
{
  [Route("posts")]
  public class PostsController : Controller
  {
    private readonly IPosts postsService;

    public PostsController(IPosts postsService)
    {
      this.postsService = postsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Index(string id)
    {
      var postDb = await this.postsService.GetById(id);
      var post = new PostViewModel(postDb, postDb.ApplicationUser, postDb.PostReplies);
      var postReplies = postDb.PostReplies.Select(reply =>
        new PostReplyViewModel(reply, reply.ApplicationUser, reply.Post));
      var model = new PostsIndexViewModel { Post = post, PostReplies = postReplies, };
      return View(model);
    }
  }
}