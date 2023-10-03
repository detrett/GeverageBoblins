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

            var users = new List<User>
            {
                new User
                    {
                        Name = "Fizzy",
                        Email = "easyfizzy@bg.com",
                        Password = "bestadmin",
                        Rank = "Admin"
                    },
                    new User
                    {
                        Name = "bubbletrouble",
                        Email = "mrbubbles@bg.com",
                        Password = "newuser",
                        Rank = "Member"
                    },
                    new User
                    {
                        Name = "Turbo",
                        Email = "master_turbo@bg.com",
                        Password = "JustTurbo",
                        Rank = "Member"
                    },
                    new User
                    {
                        Name = "m0nst3r4dd1ct",
                        Email = "monsterpunch@monster.com",
                        Password = "punch",
                        Rank = "Mod"
                    },
                    new User
                    {
                        Name = "hydration_nation",
                        Email = "h2o@bg.com",
                        Password = "water",
                        Rank = "Member"
                    },
                    new User
                    {
                        Name = "aGeverageBoblin",
                        Email = "aGeverageBoblin@bg.com",
                        Password = "geverage",
                        Rank = "Member"
                    },
                    new User
                    {
                        Name = "The Hierophant",
                        Email = "numberv@bg.com",
                        Password = "hierophant",
                        Rank = "Mod"
                    },
                    new User
                    {
                        Name = "Scratchy",
                        Email = "scratchy@bg.com",
                        Password = "scratchy",
                        Rank = "Member"
                    }
            };

            var comments = new List<Comment>
                {
                    // 8 newer comments
                    new Comment
                    {
                        UserId = 1,
                        Body = "Lorem ipsum 1...",
                        CreatedAt = new DateTime(2023, 9, 29, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 2,
                        Body = "Lorem ipsum 2...",
                        CreatedAt = new DateTime(2023, 9, 28, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 3,
                        Body = "Lorem ipsum 3...",
                        CreatedAt = new DateTime(2023, 9, 27, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 4,
                        Body = "Lorem ipsum 4...",
                        CreatedAt = new DateTime(2023, 9, 26, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 5,
                        Body = "Lorem ipsum 5...",
                        CreatedAt = new DateTime(2023, 9, 25, 11, 20, 55)
                    },
                    new Comment
                    {   
                        UserId = 6,
                        Body = "Lorem ipsum 6...",
                        CreatedAt = new DateTime(2023, 9, 24, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 7,
                        Body = "Lorem ipsum 7...",
                        CreatedAt = new DateTime(2023, 9, 23, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 8,
                        Body = "Lorem ipsum 8...",
                        CreatedAt = new DateTime(2023, 9, 22, 11, 20, 55)
                    },
                    // 8 older comments
                    new Comment
                    {
                        UserId = 8,
                        Body = "Lorem ipsum 9...",
                        CreatedAt = new DateTime(2022, 9, 22, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 7,
                        Body = "Lorem ipsum 10...",
                        CreatedAt = new DateTime(2022, 9, 23, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 6,
                        Body = "Lorem ipsum 11...",
                        CreatedAt = new DateTime(2022, 9, 24, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 5,
                        Body = "Lorem ipsum 12...",
                        CreatedAt = new DateTime(2022, 9, 25, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 4,
                        Body = "Lorem ipsum 13...",
                        CreatedAt = new DateTime(2022, 9, 26, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 3,
                        Body = "Lorem ipsum 14...",
                        CreatedAt = new DateTime(2022, 9, 27, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 2,
                        Body = "Lorem ipsum 15...",
                        CreatedAt = new DateTime(2022, 9, 28, 11, 20, 55)
                    },
                    new Comment
                    {
                        UserId = 1,
                        Body = "Lorem ipsum 16...",
                        CreatedAt = new DateTime(2022, 9, 29, 11, 20, 55)
                    },
                    // 2 Extra
                    new Comment
                    {
                        UserId = 5,
                        Body = "Lorem ipsum 17...",
                        CreatedAt = new DateTime(2023, 9, 28, 11, 19, 55)
                    },
                    new Comment
                    {
                        UserId = 7,
                        Body = "Lorem ipsum 18...",
                        CreatedAt = new DateTime(2023, 9, 29, 11, 20, 52)
                    }
                };

            var threads = new List<Models.Thread>
                {
                    // 16 Threads. 2 per subforum. 1 older, 1 newer.
                    new Models.Thread
                    {
                        UserId = 1,
                        Name = "Drink of the Year 2023 Winner Awards!",
                        Comments = new List<Comment>
                        {
                            comments[0]
                        },
                        IsLocked = true,
                        IsAnnouncement = true,
                        IsPinned = true,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 2,
                        Name = "Hi everyone :)",
                        Comments = new List<Comment>
                        {
                            comments[1]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 3,
                        Name = "Alright here we go... Pepsi Vs Coke!!",
                        Comments = new List<Comment>
                        {
                            comments[2],
                            comments[16],
                            comments[17]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = true
                    },
                    new Models.Thread
                    {
                        UserId = 4,
                        Name = "Definitive Monster flavours tier list",
                        Comments = new List<Comment>
                        {
                            comments[3]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = true,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 5,
                        Name = "WaterTok - Is flavoured water still considered water? ",
                        Comments = new List<Comment>
                        {
                            comments[4]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 6,
                        Name = "Just tried Kombucha for the first time",
                        Comments = new List<Comment>
                        {
                            comments[5]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 7,
                        Name = "Control + V Thread",
                        Comments = new List<Comment>
                        {
                            comments[6]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = true
                    },
                    new Models.Thread
                    {
                        UserId = 8,
                        Name = "Post your song of the day",
                        Comments = new List<Comment>
                        {
                            comments[7]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 1,
                        Name = "Updated list of moderators!",
                        Comments = new List<Comment>
                        {
                            comments[8]
                        },
                        IsLocked = false,
                        IsAnnouncement = true,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 2,
                        Name = "Hello!",
                        Comments = new List<Comment>
                        {
                            comments[9]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 3,
                        Name = "What even is Bitter Kas?",
                        Comments = new List<Comment>
                        {
                            comments[10]
                        },
                        IsLocked = true,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 4,
                        Name = "Why doesn't redbull make more sugar free flavors?",
                        Comments = new List<Comment>
                        {
                            comments[11]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 5,
                        Name = "I can't stop going to the bathroom",
                        Comments = new List<Comment>
                        {
                            comments[12]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 6,
                        Name = "Thoughts on Yerba Mate?",
                        Comments = new List<Comment>
                        {
                            comments[13]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = false
                    },
                    new Models.Thread
                    {
                        UserId = 7,
                        Name = "Bump thread",
                        Comments = new List<Comment>
                        {
                            comments[14]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = true
                    },
                    new Models.Thread
                    {
                        UserId = 8,
                        Name = "Post your video of the day",
                        Comments = new List<Comment>
                        {
                            comments[15]
                        },
                        IsLocked = false,
                        IsAnnouncement = false,
                        IsPinned = false,
                        IsFeatured = true
                    }
                };

            var subforums = new List<Subforum>
            {
                new Subforum {
                    Name = "Updates & Announcements",
                    Description = "Information about what's happening in the Beverage Goblins forum.",
                    Threads = new List<Models.Thread>
                    {
                        threads[0],
                        threads[8]
                    }
                },
                new Subforum
                {
                    Name = "Introduce Yourself",
                    Description = "A space for new members to introduce themselves to the community.",
                    Threads = new List<Models.Thread>
                    {
                        threads[1],
                        threads[9]
                    }
                },
                new Subforum {
                    Name = "Soft Drinks",
                    Description = "A place to discuss your favorite carbonated drinks.",
                    Threads = new List<Models.Thread>
                    {
                        threads[2],
                        threads[10]
                    }
                },
                new Subforum
                {
                    Name = "Energy Drinks",
                    Description = "For those who are in search of a little boost.",
                    Threads = new List<Models.Thread>
                    {
                        threads[3],
                        threads[11]
                    }
                },
                new Subforum {
                    Name = "Water",
                    Description = "This is a space to discuss the importance of staying hydrated in a world full of tasty drinks.",
                    Threads = new List<Models.Thread>
                    {
                        threads[4],
                        threads[12]
                    }
                },
                new Subforum
                {
                    Name = "Other Drinks",
                    Description = "Are you into smoothies, tea, kombucha or just plain old coffee? Discuss your love for all drinks that don't belong in the other forums.",
                    Threads = new List<Models.Thread>
                    {
                        threads[5],
                        threads[13]
                    }
                },
                new Subforum {
                    Name = "Off Topic",
                    Description = "Any serious topics that are unrelated to beverages should go in here.",
                    Threads = new List<Models.Thread>
                    {
                        threads[6],
                        threads[14]
                    }
                },
                new Subforum
                {
                    Name = "Daily Rumble",
                    Description = "Long-running threads in which to discuss the small things about daily life.",
                    Threads = new List<Models.Thread>
                    {
                        threads[7],
                        threads[15]
                    }
                }
            };

            var forums = new List<Forum>
                {
                    new Forum
                    {
                        Name = "Main Forums",
                        Subforums = new List<Subforum>
                        {
                            subforums[0],
                            subforums[1]
                        }

                    },
                    new Forum
                    {
                        Name = "General Discussions",
                        Subforums = new List<Subforum>
                        {
                            subforums[2],
                            subforums[3],
                            subforums[4],
                            subforums[5]
                        }
                    },
                    new Forum
                    {
                        Name = "Other Discussions",
                        Subforums = new List<Subforum>
                        {
                            subforums[6],
                            subforums[7]
                        }
                    },
                };

            if (!context.Users.Any())
            {
                var items = users;

                context.AddRange(items);
                context.SaveChanges();
            }

            if (!context.Threads.Any())
            {
                var items = threads;

                context.AddRange(items);
                context.SaveChanges();
            }

            if (!context.Subforums.Any())
            {
                var items = subforums;

                context.AddRange(items);
                context.SaveChanges();
            }

            if (!context.Forums.Any())
            {
                var items = forums;

                context.AddRange(items);
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                var items = comments;

                context.AddRange(items);
                context.SaveChanges();
            }
        }
    }
}
