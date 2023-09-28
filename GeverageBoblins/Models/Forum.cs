using System.ComponentModel.DataAnnotations;

namespace GeverageBoblins.Models
{
    public class Forum
    {
        public int ForumId { get; set; }

        [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,20}", 
            ErrorMessage = "The Name must be numbers or letters and between 2 to 20 characters long.")]
        public string Name { get; set; } = string.Empty; // Example: 'Main Forum'

    }
}
