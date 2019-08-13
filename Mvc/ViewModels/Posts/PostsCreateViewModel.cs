namespace Mvc.ViewModels.Posts
{
  public class PostsCreateViewModel
  {
    public ForumViewModel Forum { get; set; }
    public ApplicationUserViewModel Author { get; set; }
    public PostViewModel Post { get; set; }
  }
}