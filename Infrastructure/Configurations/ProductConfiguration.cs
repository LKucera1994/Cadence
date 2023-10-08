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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Nite Speedster Bike 2000",
                    Description = "Sample Description",
                    Price = 200,
                    PhotoUrl = "images/products/sb-ang1.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 1
                },

                new Product
                {
                    Id = 2,
                    Name = "Green Nite Bike 3000",
                    Description = "Sample Description",
                    Price = 150,
                    PhotoUrl = "images/products/sb-ang2.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Speed Bike Speed Rush 3",
                    Description = "Sample Description",
                    Price = 180,
                    PhotoUrl = "images/products/sb-core1.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Speed Super Bike",
                    Description = "Sample Description",
                    Price = 300,
                    PhotoUrl = "images/products/sb-core2.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Bassos Bike Super Whizzy Fast",
                    Description = "Sample Description",
                    Price = 250,
                    PhotoUrl = "images/products/sb-react1.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 6,
                    Name = "Porco Bike Entry",
                    Description = "Sample Description",
                    Price = 120,
                    PhotoUrl = "images/products/sb-ts1.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 5
                },
                new Product
                {
                    Id = 7,
                    Name = "Speed Blue Hat",
                    Description = "Sample Description",
                    Price = 10,
                    PhotoUrl = "images/products/hat-core1.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Green Bassos Woolen Hat",
                    Description = "Sample Description",
                    Price = 8,
                    PhotoUrl = "images/products/hat-react1.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Purple Bassos Woolen Hat",
                    Description = "Sample Description",
                    Price = 15,
                    PhotoUrl = "images/products/hat-react2.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 10,
                    Name = "Blue Despair Gloves",
                    Description = "Sample Description",
                    Price = 18,
                    PhotoUrl = "images/products/glove-code1.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Green Despair Gloves",
                    Description = "Sample Description",
                    Price = 15,
                    PhotoUrl = "images/products/glove-code2.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Id = 12,
                    Name = "Purple Bassos Gloves",
                    Description = "Sample Description",
                    Price = 16,
                    PhotoUrl = "images/products/glove-react1.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 13,
                    Name = "Green Bassos Gloves",
                    Description = "Sample Description",
                    Price = 14,
                    PhotoUrl = "images/products/glove-react2.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 14,
                    Name = "Pavic Parts Red Boots",
                    Description = "Sample Description",
                    Price = 250,
                    PhotoUrl = "images/products/boot-redis1.jpg",
                    ProductTypeId = 3,
                    ProductBrandId = 6
                },
                new Product
                {
                    Id = 15,
                    Name = "Speed Boots",
                    Description = "Sample Description",
                    Price = 189,
                    PhotoUrl = "images/products/boot-core2.jpg",
                    ProductTypeId = 3,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 16,
                    Name = "Speed Purple Boots",
                    Description = "Sample Description",
                    Price = 199,
                    PhotoUrl = "images/products/boot-core1.jpg",
                    ProductTypeId = 3,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 17,
                    Name = "Nite Purple Boots",
                    Description = "Sample Description",
                    Price = 150,
                    PhotoUrl = "images/products/boot-ang2.jpg",
                    ProductTypeId = 3,
                    ProductBrandId = 1
                },
                new Product
                {
                    Id = 18,
                    Name = "Nite Blue Boots",
                    Description = "Sample Description",
                    Price = 180,
                    PhotoUrl = "images/products/boot-ang1.jpg",
                    ProductTypeId = 3,
                    ProductBrandId = 1
                }

                );
        }
    }
}
