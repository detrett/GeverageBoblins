using GeverageBoblins.DAL;
using Microsoft.EntityFrameworkCore;

// Create builder
var builder = WebApplication.CreateBuilder(args);

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

// Adding the Forum Repository
builder.Services.AddScoped<IForumRepository, ForumRepository>();
// Adding the Subforum Repository
builder.Services.AddScoped<ISubforumRepository, SubforumRepository>();
// Adding the Thread Repository
builder.Services.AddScoped<IThreadRepository, ThreadRepository>();

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

// Middleware: route controller => action (E.g, Forum/Container maps the action Container to the ForumController)
app.MapDefaultControllerRoute();

// Middleware: execute application
app.Run();
