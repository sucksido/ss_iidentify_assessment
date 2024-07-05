using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ForumAPI.Data;
using ForumAPI.Models;

namespace ForumAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumContext _context;

        public CommentRepository(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(c => c.User).Include(c => c.Post).ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(c => c.User).Include(c => c.Post).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> FindAsync(System.Linq.Expressions.Expression<Func<Comment, bool>> predicate)
        {
            return await _context.Comments.Where(predicate).ToListAsync();
        }
    }
}