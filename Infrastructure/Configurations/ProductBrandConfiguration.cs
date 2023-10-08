using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasData(

                new ProductBrand
                {
                    Id = 1,
                    Name = "Nite"
                },
                new ProductBrand
                {
                    Id = 2,
                    Name = "Speed"
                },
                new ProductBrand
                {
                    Id = 3,
                    Name = "Despair"
                },
                new ProductBrand
                {
                    Id = 4,
                    Name = "Bassos"
                },
                new ProductBrand
                {
                    Id = 5,
                    Name = "Porco Bicycles"
                },
                new ProductBrand
                {
                    Id = 6,
                    Name = "Pavic Parts"
                }
            );
        }
    }
}
