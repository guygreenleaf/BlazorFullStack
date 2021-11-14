using BlazorApp1.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=localhost;Database=test;Trusted_Connection=True;"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7209", "https://localhost:5209")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();
