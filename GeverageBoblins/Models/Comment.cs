using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeverageBoblins.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
