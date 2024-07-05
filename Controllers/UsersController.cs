using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForumAPI.Models;
using ForumAPI.Data;
using ForumAPI.Services;
using Microsoft.EntityFrameworkCore;


namespace ForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ForumContext _context;
        private readonly TokenService _tokenService;

        public UsersController(ForumContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists");
            }

            // Initialize navigation properties
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Posts = new List<Post>();
            user.Comments = new List<Comment>();
            user.Likes = new List<Like>();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User loginUser)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginUser.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password))
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(user.Username, user.Role);
            return Ok(new { token });
        }
    }
}