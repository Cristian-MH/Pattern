using CleanShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanShop.Infrastructure.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Order>(cfg =>
        {
            cfg.HasKey(o => o.Id);
            cfg.Property(o => o.CustomerEmail).IsRequired().HasMaxLength(320);

            cfg.Ignore(o => o.Items);

            cfg.OwnsMany<OrderItem>("_items", nav =>
            {
                nav.WithOwner().HasForeignKey("OrderId");
                nav.ToTable("OrderItems");
                nav.Property<Guid>("Id");
                nav.HasKey("Id");

                nav.Property(p => p.Sku).HasMaxLength(64).IsRequired();
                nav.Property(p => p.Quantity).IsRequired();
                nav.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            });
        });
    }
}
