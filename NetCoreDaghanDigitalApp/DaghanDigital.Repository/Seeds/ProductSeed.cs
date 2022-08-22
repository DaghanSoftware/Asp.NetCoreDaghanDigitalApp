using DaghanDigital.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaghanDigital.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product {Id=1,CategoryId=1,ProductName= "Silver Package", Price=100,Stock=20,CreateDate=DateTime.Now, },
                new Product { Id = 2, CategoryId = 1, ProductName = "Gold Package", Price = 200, Stock = 20, CreateDate = DateTime.Now, },
                new Product { Id = 3, CategoryId = 1, ProductName = "Diamond Package", Price = 300, Stock = 20, CreateDate = DateTime.Now, },
                new Product { Id = 4, CategoryId = 2, ProductName = "En güçlü işlemciye sahip sunucu -Premium Sunucu-", Price = 1000, Stock = 10, CreateDate = DateTime.Now, },
                new Product { Id = 5, CategoryId = 2, ProductName = "Normal Kullanıcılar için -Standart Sunucu-", Price = 500, Stock = 15, CreateDate = DateTime.Now, }
                );
        }
    }
}
