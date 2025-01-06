using Microsoft.EntityFrameworkCore;
using Online_Survey.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context with the connection string from appsettings.json
builder.Services.AddDbContext<OnlineDbCon>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection"))
);

// Add session services with configuration (you can adjust the timeout and cookie settings as needed)
builder.Services.AddDistributedMemoryCache(); // Required for session storage
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
	options.Cookie.HttpOnly = true; // Make the cookie accessible only via HTTP
	options.Cookie.IsEssential = true; // Make the cookie essential for app functionality
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Enable HTTPS Redirection in production
    app.UseHsts();
}

// Serve static files from the wwwroot folder
app.UseStaticFiles();


app.UseSession();

// Enable routing
app.UseRouting();

// Enable authorization middleware (if you have any authorization in place)
app.UseAuthorization();

// Configure the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=home}/{id?}"
);

app.Run();
