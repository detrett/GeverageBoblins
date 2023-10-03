using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeverageBoblins.Models
{
    [Table("Thread")]
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual List<Comment>? Comments { get; set; } // List of comments inside of a thread 
        public virtual Subforum? ParentSubforum { get; set; }

        public Boolean IsLocked { get; set; }
        public Boolean IsAnnouncement { get; set; }
        public Boolean IsPinned { get; set; }
        public Boolean IsFeatured { get; set; }
 
    }
}
