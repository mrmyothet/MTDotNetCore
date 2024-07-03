using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.MVCAppAjax.Models;

namespace MTDotNetCore.MVCAppAjax.Db;

public class AppDbContext : DbContext
{
    // Replace with Dependency Injection configured at Program.cs

    public AppDbContext(DbContextOptions options)
        : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //base.OnConfiguring(optionsBuilder);

    //    optionsBuilder.UseSqlServer(
    //        ConnectionStrings.sqlConnectionStringBuilder.ConnectionString
    //    );
    //}

    public DbSet<BlogModel> Blogs { get; set; }
}
