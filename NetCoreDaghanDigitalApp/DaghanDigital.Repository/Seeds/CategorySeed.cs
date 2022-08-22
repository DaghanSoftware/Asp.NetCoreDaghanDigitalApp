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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, CategoryName = "Paketler" }, 
                new Category { Id = 2, CategoryName = "Sunucular" },
                new Category { Id = 3, CategoryName = "Domainler" }
                );
        }
    }
}
