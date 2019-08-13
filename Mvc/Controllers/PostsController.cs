using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Lib.Data.Models;
using Lib.Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using Mvc.ViewModels.Posts;

namespace Mvc.Controllers
{
  [Route("posts")]
  public class PostsController : Controller
  {
    private readonly IPosts postsService;
    private readonly IForums forumsService;
    private readonly UserManager<ApplicationUser> userManager;

    public PostsController(
      IPosts postsService,
      IForums forumsService,
      UserManager<ApplicationUser> userManager)
    {
      this.postsService = postsService;
      this.forumsService = forumsService;
      this.userManager = userManager;
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

    [HttpGet("create/{forumId}")]
    public async Task<ActionResult> Create(string forumId)
    {
      var forumDb = await this.forumsService.GetById(forumId);
      var userDb = await this.userManager.GetUserAsync(User);
      var model = new PostsCreateViewModel
      {
        Forum = new ForumViewModel(forumDb),
        Author = new ApplicationUserViewModel(userDb),
        Post = new PostViewModel
        {
          AuthorId = userDb.Id,
          ForumId = forumDb.Id,
        }
      };
      return View(model);
    }

    [HttpPost("add")]
    public async Task<ActionResult> Add(PostViewModel newPost)
    {
      var post = newPost.GetModel(newPost);
      post.CreatedAt = DateTime.UtcNow;
      post.ApplicationUser = await this.userManager.FindByIdAsync(newPost.AuthorId);
      post.Forum = await this.forumsService.GetById(newPost.ForumId);
      await this.postsService.Create(post);
      // TODO: implement user rating management
      return RedirectToAction("Index", "Posts", new { id = post.Id });
    }
  }
}