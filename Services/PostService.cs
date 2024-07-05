using System.Collections.Generic;
using System.Threading.Tasks;
using ForumAPI.Models;
using ForumAPI.Repositories;

namespace ForumAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PostService(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
            return post;
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserAsync(int userId)
        {
            return await _postRepository.GetPostsByUserAsync(userId);
        }

        public async Task<IEnumerable<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _postRepository.GetPostsByDateRangeAsync(startDate, endDate);
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await _commentRepository.AddAsync(comment);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _commentRepository.GetCommentsByPostIdAsync(postId);
        }
    }
}