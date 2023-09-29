namespace GeverageBoblins.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ThreadId { get; set; }
        public int AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
