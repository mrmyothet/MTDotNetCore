using Microsoft.EntityFrameworkCore;
using MTDotNetCore.PaginationAPI.Models;

namespace MTDotNetCore.PaginationAPI.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<BlogModel> Blogs { get; set; }
}
