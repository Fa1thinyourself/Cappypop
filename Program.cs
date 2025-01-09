using dotenv.net;
using Supabase;
using static System.Net.WebRequestMethods;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

var url = "https://ikgjbacpuzcnghxcrzwc.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImlrZ2piYWNwdXpjbmdoeGNyendjIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzYyNjA1MzksImV4cCI6MjA1MTgzNjUzOX0.xMQTgFW1v31DEI-pZbYCWF6JoZ-yvtBvFk_fU598nw4";
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

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
