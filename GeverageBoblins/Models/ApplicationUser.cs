using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GeverageBoblins.Models
{
    public class ApplicationUser : IdentityUser<int> // Using int as the primary key type
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        public string Rank { get; set; } // Member, Moderator, Admin
        
        public string? Password { get; set; }
        

        public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
        public virtual ICollection<Comment> UserComments { get; set; } = new List<Comment>();
    }
}
