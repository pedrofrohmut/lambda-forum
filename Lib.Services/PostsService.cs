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

    public async Task Create(Post newPost)
    {
      await this.context.Posts.AddAsync(newPost);
      await this.context.SaveChangesAsync();
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

    public async Task<IEnumerable<Post>> GetAll() =>
      await this.context.Posts
        .Include(post => post.ApplicationUser)
        .Include(post => post.PostReplies)
        .ThenInclude(reply => reply.ApplicationUser)
        .Include(post => post.Forum)
        .OrderByDescending(post => post.CreatedAt)
        .ToListAsync();

    public async Task<IEnumerable<Post>> GetByForumId(string forumId) =>
      await this.context.Posts
        .Where(post => post.Forum.Id == forumId)
        .ToListAsync();

    public async Task<Post> GetById(string id) =>
      await this.context.Posts
        .Include(post => post.Forum)
        .Include(post => post.ApplicationUser)
        .Include(post => post.PostReplies)
        .ThenInclude(reply => reply.ApplicationUser)
        .FirstOrDefaultAsync(post => post.Id == id);

    public async Task<IEnumerable<Post>> GetLatestPosts(int amount) =>
      await this.context.Posts
        .Include(post => post.ApplicationUser)
        .Include(post => post.PostReplies)
        .ThenInclude(reply => reply.ApplicationUser)
        .Include(post => post.Forum)
        .OrderByDescending(post => post.CreatedAt)
        .Take(amount)
        .ToListAsync();
  }
}