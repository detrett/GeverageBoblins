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
        public DbSet<Subforum> Subforums { get; set; }
        public DbSet<Models.Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
