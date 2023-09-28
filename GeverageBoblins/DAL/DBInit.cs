using GeverageBoblins.Models;

namespace GeverageBoblins.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            ForumDbContext context = serviceScope.ServiceProvider.GetRequiredService<ForumDbContext>();

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            if (!context.Forums.Any())
            {
                var items = new List<Forum>
                {
                    new Forum
                    {
                        Name = "Main Forum"
                    },
                    new Forum
                    {
                        Name = "General Forum"
                    },
                    new Forum
                    {
                        Name = "Other Discussions"
                    },
                };

                context.AddRange(items);
                context.SaveChanges();
            }

        }
    }
}
