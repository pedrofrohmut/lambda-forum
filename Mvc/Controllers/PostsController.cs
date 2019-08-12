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

    [HttpGet]
    public async Task<ActionResult> Index(string id)
    {
      var postDb = await this.postsService.GetById(id);
      var post =
        new PostViewModel
        {
          Id = postDb.Id,
          Title = postDb.Title,
          Content = postDb.Content,
          CreatedAt = postDb.CreatedAt,
          AuthorId = postDb.ApplicationUser.Id,
          AuthorName = postDb.ApplicationUser.UserName,
          AuthorRating = postDb.ApplicationUser.Rating,
          PostRepliesCount = postDb.PostReplies.Count(),
        };
      var postReplies =
        postDb.PostReplies.Select(reply =>
          new PostReplyViewModel
          {
            Id = reply.Id,
            Content = reply.Content,
            CreatedAt = reply.CreatedAt,
            AuthorId = reply.ApplicationUser.Id,
            AuthorName = reply.ApplicationUser.UserName,
            AuthorRating = reply.ApplicationUser.Rating,
            AuthorImageUrl = reply.ApplicationUser.ProfileImageUrl,
            PostId = reply.Post.Id,
          }
        );
      var model =
        new PostsIndexViewModel
        {
          Post = post,
          PostReplies = postReplies,
        };
      return View(model);
    }
  }
}