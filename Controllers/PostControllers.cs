using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ForumAPI.Models;
using ForumAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        var createdPost = await _postService.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        await _postService.UpdatePostAsync(post);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }

    [Authorize]
    [HttpPost("{id}/comments")]
    public async Task<ActionResult<Comment>> AddComment(int id, Comment comment)
    {
        comment.PostId = id;
        var createdComment = await _postService.AddCommentAsync(comment);
        return CreatedAtAction(nameof(GetComments), new { id = id, commentId = createdComment.Id }, createdComment);
    }

    [HttpGet("{id}/comments")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
    {
        var comments = await _postService.GetCommentsByPostIdAsync(id);
        return Ok(comments);
    }
}