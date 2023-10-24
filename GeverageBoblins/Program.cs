using GeverageBoblins.DAL;
using GeverageBoblins.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

// Create builder
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ForumDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ItemDbContextConnection' not found.");

// Inject MVC model into builder
builder.Services.AddControllersWithViews();

// Insert NewtonsoftJson to avoid infinite loops
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling =
     Newtonsoft.Json.ReferenceLoopHandling.Ignore;

});

// Allows us to use DB Contexts
builder.Services.AddDbContext<ForumDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ForumDbContextConnection"]);
});

// Add Identity services
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = true; // Require at least one digit in the password
        options.Password.RequireNonAlphanumeric = true; // Require at least one non-alphanumeric character
        options.Password.RequireUppercase = true; // Require at least one uppercase letter

    })
    .AddEntityFrameworkStores<ForumDbContext>();

// Configure lockout settings
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // Lockout duration
    options.Lockout.MaxFailedAccessAttempts = 5; // Maximum number of failed attempts before lockout
    options.Lockout.AllowedForNewUsers = false; // Whether lockout is enabled for new users
});


// Adding the Forum Repository
builder.Services.AddScoped<IForumRepository, ForumRepository>();
// Adding the Subforum Repository
builder.Services.AddScoped<ISubforumRepository, SubforumRepository>();
// Adding the Thread Repository
builder.Services.AddScoped<IThreadRepository, ThreadRepository>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddRazorPages();
builder.Services.AddSession();
// Build application
var app = builder.Build();

// DB Init
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

// Allows using the files under wwwroot
app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

// Middleware: route controller => action (E.g, Forum/Container maps the action Container to the ForumController)
app.MapDefaultControllerRoute();

app.MapRazorPages();
// Middleware: execute application
app.Run();
