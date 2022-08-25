using DaghanDigital.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DaghanDigital.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color = "Kırmızı",
                Height = 100,
                Width = 200,
                ProductId = 5
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Beyaz",
                Height = 200,
                Width = 300,
                ProductId = 4
            }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
