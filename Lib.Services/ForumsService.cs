using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Data.Models;
using Lib.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services
{
  public class ForumsService : IForums
  {
    private readonly ApplicationDbContext context;

    public ForumsService(ApplicationDbContext context) { this.context = context; }

    public Task Create(Forum newForum)
    {
      throw new System.NotImplementedException();
    }

    public Task DeleteById(string id)
    {
      throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Forum>> GetAll() =>
      await this.context.Forums
        .Include(forum => forum.Posts)
        .ToListAsync();

    public Task<IEnumerable<ApplicationUser>> GetAllActiveUsers()
    {
      throw new System.NotImplementedException();
    }

    public async Task<Forum> GetById(string id) =>
      await this.context.Forums
        .Include(forum => forum.Posts)
        .ThenInclude(post => post.ApplicationUser)
        .Include(forum => forum.Posts)
        .ThenInclude(post => post.PostReplies)
        .ThenInclude(reply => reply.ApplicationUser)
        .FirstOrDefaultAsync(forum => forum.Id == id);

    public Task UpdateDescritionById(string id, string newDescription)
    {
      throw new System.NotImplementedException();
    }

    public Task UpdateTitleById(string id, string newTitle)
    {
      throw new System.NotImplementedException();
    }
  }
}