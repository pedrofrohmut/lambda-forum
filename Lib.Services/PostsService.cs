using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.Data.Models;
using Lib.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services
{
  public class PostsService : IPosts
  {
    private readonly ApplicationDbContext context;

    public PostsService(ApplicationDbContext context)
    {
      this.context = context;
    }

    public Task Create(Post newPost)
    {
      throw new System.NotImplementedException();
    }

    public Task CreateReplyByPostId(string postId, PostReply newReply)
    {
      throw new System.NotImplementedException();
    }

    public Task DeleteById(string id)
    {
      throw new System.NotImplementedException();
    }

    public Task EditContent(string id, string newContent)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAll()
    {
      throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Post>> GetByForumId(string forumId) =>
      await this.context.Posts
        .Where(post => post.Forum.Id == forumId)
        .ToListAsync();

    public Task<Post> GetById(string id)
    {
      throw new System.NotImplementedException();
    }
  }
}