using dotenv.net;
using Supabase;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

var url = Environment.GetEnvironmentVariable("SUPABASE_URL") ?? throw new InvalidOperationException("Environment variable 'SUPABASE_URL' not found");
var key = Environment.GetEnvironmentVariable("SUPABASE_KEY") ?? throw new InvalidOperationException("Environment variable 'SUPABASE_KEY' not found");
var option = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
    // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
};
// Note the creation as a singleton.
builder.Services.AddSingleton(provider => new Client(url, key, option));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
