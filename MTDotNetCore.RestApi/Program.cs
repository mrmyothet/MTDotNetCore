using Microsoft.EntityFrameworkCore;
using MTDotNetCore.RestApi.Db;
using MTDotNetCore.Shared;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7211", "http://localhost:5226");
        }
    );
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;
string connectionString = builder.Configuration.GetConnectionString("DbConnection2")!;

//builder.Services.AddScoped<AdoDotNetService>(n=> new AdoDotNetService(connectionString));
builder.Services.AddScoped(n => new AdoDotNetService(connectionString));

//builder.Services.AddScoped<DapperService>(n=> new DapperService(connectionString));
builder.Services.AddScoped(n => new DapperService(connectionString));

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    },
    ServiceLifetime.Transient
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
