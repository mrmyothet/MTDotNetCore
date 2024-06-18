using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTDotNetCore.ConsoleApp.Dtos;
using MTDotNetCore.ConsoleApp.Services;

namespace MTDotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        // Use Microsoft.Extensions.DependencyInjection NuGet Package
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        //}
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
