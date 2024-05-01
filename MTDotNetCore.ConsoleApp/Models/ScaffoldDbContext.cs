using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MTDotNetCore.ConsoleApp.Models;

public partial class ScaffoldDbContext : DbContext
{
    public ScaffoldDbContext()
    {
    }

    public ScaffoldDbContext(DbContextOptions<ScaffoldDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MYOTHETPC\\MSSQLSERVER2012;Database=DotNetTrainingBatch4;User ID=MYOTHETPC\\Administrator;Password=admin123!;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
