using Microsoft.EntityFrameworkCore;
using OnionShop.Domain.Entities;

namespace OnionShop.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Product>(cfg =>
        {
            cfg.HasKey(p => p.Id);
            cfg.HasIndex(p => p.Sku).IsUnique();
            cfg.Property(p => p.Sku).HasMaxLength(64).IsRequired();
            cfg.Property(p => p.Name).HasMaxLength(200).IsRequired();
            cfg.Property(p => p.Price).HasPrecision(18, 2);
        });
    }
}
