using System;
using System.Collections.Generic;
using Entity;
using Environment.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repository;

public class BaseContext : DbContext
{
    private readonly DatabaseConnectionString _connectionString;

    public BaseContext()
    {
        
    }
    public BaseContext(IOptions<DatabaseConnectionString> connectionString, DbSet<Category> categories, DbSet<Product> products)
    {
        Categories = categories;
        Products = products;
        _connectionString = connectionString.Value;
    }

    public BaseContext(DbContextOptions<BaseContext> options, DatabaseConnectionString connectionString, DbSet<Category> categories, DbSet<Product> products)
        : base(options)
    {
        _connectionString = connectionString;
        Categories = categories;
        Products = products;
    }

    private DbSet<Category> Categories { get; set; }

    private DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString.SqlServerConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        
    }
}
