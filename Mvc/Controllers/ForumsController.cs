using System.Linq;
using System.Threading.Tasks;
using Lib.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;
using Mvc.ViewModels.Forums;

namespace Mvc.Controllers
{
  [Route("/forums")]
  public class ForumsController : Controller
  {
    private readonly IForums forumsService;

    public ForumsController(IForums forumsService)
    {
      this.forumsService = forumsService;
    }

    [HttpGet]
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
  }
}