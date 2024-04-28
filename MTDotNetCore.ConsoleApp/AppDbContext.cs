﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDotNetCore.ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
