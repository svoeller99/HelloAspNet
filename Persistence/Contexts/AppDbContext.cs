using System;
using HelloAspNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelloAspNet.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // DUDE! what is this extends syntax at the method level?

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EntityTypeBuilder<Category> categoryTypeBuilder = builder.Entity<Category>();
            categoryTypeBuilder.ToTable("Categories").HasKey(p => p.Id);
            categoryTypeBuilder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            categoryTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            categoryTypeBuilder.HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            
            // NOTE: In-memory provider doesn't enforce this - see https://github.com/aspnet/EntityFrameworkCore/issues/3850
            categoryTypeBuilder.HasIndex(p => p.Name).IsUnique().HasName("UK_Categories_Name");

            categoryTypeBuilder.HasData
            (
              new Category { Id = 100, Name = "Fruits and Vegetables" },
              new Category { Id = 101, Name = "Dairy" }
            );

            EntityTypeBuilder<Product> productTypeBuilder = builder.Entity<Product>();
            productTypeBuilder.ToTable("Products");
            productTypeBuilder.HasKey(p => p.Id);
            productTypeBuilder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            productTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            productTypeBuilder.Property(p => p.QuantityInPackage).IsRequired();
            productTypeBuilder.Property(p => p.UnitOfMeasurement).IsRequired();
        }
    }
}