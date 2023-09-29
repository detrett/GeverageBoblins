namespace GeverageBoblins.Models
{
    public class Thread
    {
        public int ThreadId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual List<Comment>? Comments { get; set; } // List of comments inside of a thread 


    }
}
