namespace GeverageBoblins.Models
{
    public class SubforumThreadComment
    {
        public Subforum Subforum { get; set; }
        public Thread? newThread { get; set; }
        public Comment? newComment { get; set; }
    }
}
