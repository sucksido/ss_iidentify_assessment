using System.Collections.Generic;
using System.Threading.Tasks;
using ForumAPI.Models;

namespace ForumAPI.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<IEnumerable<Post>> GetPostsByUserAsync(int userId);
        Task<IEnumerable<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}