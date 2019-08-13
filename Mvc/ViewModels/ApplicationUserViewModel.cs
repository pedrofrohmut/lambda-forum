using Lib.Data.Models;

namespace Mvc.ViewModels
{
  public class ApplicationUserViewModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Rating { get; set; }
    public string ImageUrl { get; set; }

    public ApplicationUserViewModel(ApplicationUser userDb)
    {
      this.Id = userDb.Id;
      this.Name = userDb.UserName;
      this.Email = userDb.Email;
      this.Rating = userDb.Rating;
      this.ImageUrl = userDb.ProfileImageUrl;
    }
  }
}