using Microsoft.EntityFrameworkCore;
using MTDotNetCore.PaginationMvc.Models;

namespace MTDotNetCore.PaginationMvc.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<BlogModel> Blogs { get; set; }
}
