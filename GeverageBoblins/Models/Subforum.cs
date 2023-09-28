using System.ComponentModel.DataAnnotations;

namespace GeverageBoblins.Models
{
    public class Subforum
    {
        public int SubforumId { get; set; }

        [RegularExpression(@"[0-9a-zA-ZæøåÆØÅ. \-]{2,20}",
            ErrorMessage = "The Name must be numbers or letters and between 2 to 20 characters long.")]
        public string Name { get; set; } = string.Empty; // Example: 'Introduce Yourself'

        public string Description { get; set; } = string.Empty; // Example: 'A space for new members to introduce themselves to the community.'

        public string? BackgroundColor { get; set; } // Options: 'dark' or 'light'

    }
}
