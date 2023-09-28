using GeverageBoblins.Models;
using Microsoft.EntityFrameworkCore;

namespace GeverageBoblins.DAL
{
    public class ForumDbContext : DbContext
    {
        // The Forum's DB Constructor
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Forum> Forums { get; set; }

    }
}
