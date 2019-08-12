using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Data.Models;

namespace Lib.Data.Services
{
  public interface IPosts
  {
    /*
      CREATE: Create a new post
    */
    Task Create(Post newPost);

    /*
      CREATE: Create a reply for a post
    */
    Task CreateReplyByPostId(string postId, PostReply newReply);

    /*
      READ: Get a post biy its id
    */
    Task<Post> GetById(string id);

    /*
      READ: Get all posts
    */
    Task<IEnumerable<Post>> GetAll();

    /*
      READ: Get all post for a specific forum
    */
    Task<IEnumerable<Post>> GetByForumId(string forumId);

    /*
      UPDATE: Edit post content
    */
    Task EditContent(string id, string newContent);

    /*
      DELETE: Remove a post by its id
    */
    Task DeleteById(string id);
  }
}