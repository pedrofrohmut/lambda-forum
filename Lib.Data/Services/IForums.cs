using System.Collections.Generic;
using System.Threading.Tasks;
using Lib.Data.Models;

namespace Lib.Data.Services
{
  public interface IForums
  {
    /*
      CREATE: Create a Forum
    */
    Task Create(Forum newForum);

    /*
      READ: Get Forum By its id
    */
    Task<Forum> GetById(string id);

    /*
      READ: Get All Forums
    */
    Task<IEnumerable<Forum>> GetAll();

    /*
      READ: Get All Active ApplicationUsers
    */
    Task<IEnumerable<ApplicationUser>> GetAllActiveUsers();

    /*
      UPDATE: Update Forum Title by its id
    */
    Task UpdateTitleById(string id, string newTitle);

    /*
      UPDATE: Update Forum Description by its id
    */
    Task UpdateDescritionById(string id, string newDescription);

    /*
      DELETE: Delete a Forum by its id
    */
    Task DeleteById(string id);
  }
}