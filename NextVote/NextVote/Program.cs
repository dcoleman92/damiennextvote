using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

var config = new HttpConfiguration();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{inventory}/{action=getall}}");

app.MapFallbackToFile("index.html"); ;

app.UseCors();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

config.EnableCors();

app.Run();



