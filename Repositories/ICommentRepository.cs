using System.Collections.Generic;
using System.Threading.Tasks;
using ForumAPI.Models;

namespace ForumAPI.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}