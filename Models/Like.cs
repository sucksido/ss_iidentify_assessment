namespace ForumAPI.Models
{
    public class Like
    {
        public int PostId { get; set; }
        public Post Post { get; set; } = default!;
        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}