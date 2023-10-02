using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeverageBoblins.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? Rank { get; set; } // Member, Moderator, Admin
        public virtual ICollection<Models.Thread>? Threads { get; set; } // Collection of the user's threads
        public virtual List<Comment>? UserComments { get; set; } // Collection of the user's comments
    }
}
