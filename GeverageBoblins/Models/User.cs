namespace GeverageBoblins.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? Rank { get; set; } // Member, Moderator, Admin
        public virtual List<Models.Thread>? Threads { get; set; } // Collection of the user's threads
        public virtual List<Comment>? Comments { get; set; } // Collection of the user's comments
    }
}
