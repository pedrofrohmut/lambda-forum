using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.ViewModels;

namespace Mvc.Controllers
{
  [Route("home")]
  public class HomeController : Controller
  {
    [HttpGet("index")]
    public IActionResult Index()
    {
      return View();
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
