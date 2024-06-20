using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MinimalApi.Db;

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

app.MapGet(
    "api/Blog",
    async (AppDbContext db) =>
    {
        var lst = await db.Blogs.AsNoTracking().ToListAsync();
        return Results.Ok(lst);
    }
);

app.Run();
