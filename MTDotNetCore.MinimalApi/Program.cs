using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MinimalApi.Db;
using MTDotNetCore.MinimalApi.Features.Blog;
using MTDotNetCore.MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnection = builder.Configuration.GetConnectionString("DbConnection")!;

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(dbConnection);
    },
    ServiceLifetime.Transient,
    ServiceLifetime.Transient
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World");

//BlogService.MapBlogs(app);
app.MapBlogs();

app.Run();
