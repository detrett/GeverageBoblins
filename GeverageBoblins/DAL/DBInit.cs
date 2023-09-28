using GeverageBoblins.Models;
using Microsoft.VisualBasic;

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
                        Name = "Main Forums",
                        Subforums = new List<Subforum>
                        {
                            new Subforum {
                             Name = "Updates & Announcements",
                             Description = "Information about what's happening in the Beverage Goblins forum."
                            },
                            new Subforum
                            {
                             Name = "Introduce Yourself",
                             Description = "A space for new members to introduce themselves to the community."
                            }
                        }
                        
                    },
                    new Forum
                    {
                        Name = "General Discussions",
                        Subforums = new List<Subforum>
                        {
                            new Subforum {
                             Name = "Soft Drinks",
                             Description = "A place to discuss your favorite carbonated drinks."
                            },
                            new Subforum
                            {
                             Name = "Energy Drinks",
                             Description = "For those who are in search of a little boost."
                            },
                            new Subforum {
                             Name = "Water",
                             Description = "This is a space to discuss the importance of staying hydrated in a world full of tasty drinks."
                            },
                            new Subforum
                            {
                             Name = "Other Drinks",
                             Description = "Are you into smoothies, tea, kombucha or just plain old coffee? Discuss your love for all drinks that don't belong in the other forums."
                            }
                        }
                    },
                    new Forum
                    {
                        Name = "Other Discussions",
                        Subforums = new List<Subforum>
                        {
                            new Subforum {
                             Name = "Off Topic",
                             Description = "Any serious topics that are unrelated to beverages should go in here."
                            },
                            new Subforum
                            {
                             Name = "Daily Rumble",
                             Description = "Long-running threads in which to discuss the small things about daily life."
                            }
                        }
                    },
                };

                context.AddRange(items);
                context.SaveChanges();
            }
        }
    }
}
