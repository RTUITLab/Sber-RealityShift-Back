﻿using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Database
{
    public class SberDbContext : DbContext
    {
        public SberDbContext(DbContextOptions<SberDbContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
    }
}