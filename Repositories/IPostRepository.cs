using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ForumAPI.Models;

namespace ForumAPI.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUserAsync(int userId);
        Task<IEnumerable<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}