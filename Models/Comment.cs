namespace ForumAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; } = default!;
        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}