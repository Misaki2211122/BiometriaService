using Application.Abstractions.Database;
using Application.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiometriaService.Database.Context;

public class BiometriaServiceContext: DbContext, IBiometriaServiceContext
{
    public DbSet<AndroidEntity> Android { get; set; }

    /// <summary>
    /// BiometriaServiceContext
    /// </summary>
    /// <param name="options"></param>
    public BiometriaServiceContext(DbContextOptions<BiometriaServiceContext> options) : base(options)
    {
        Database.EnsureCreated(); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}