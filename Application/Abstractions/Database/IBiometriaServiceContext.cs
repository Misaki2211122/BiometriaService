using Application.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Database;

public interface IBiometriaServiceContext
{
    /// <summary>
    /// Контекст Users
    /// </summary>
    public DbSet<AndroidEntity> Android { get; set; }
}