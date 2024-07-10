using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGSWebApp.Application.Common.Interfaces;
using SGSWebApp.Core.Data;

namespace SGSWebApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Container> Containers { get; set; }
    public DbSet<Operation> Operations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
