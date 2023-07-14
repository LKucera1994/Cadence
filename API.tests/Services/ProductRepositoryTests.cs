using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadence.Tests.Services
{
    public class ProductRepositoryTests
    {
        private DataContext _dataContext;

        
        public ProductRepositoryTests()
        {
            // Set up the data context with test data
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ProductDatabase")
                .Options;
            _dataContext = new DataContext(options);
            _dataContext.Products.Add(new Product {
                Id = 1,
                Name = "Nite Speedster Board 2000",
                Description ="Sample Description",
                Price = 200,
                PhotoUrl = "images/products/sb-ang1.png",
                ProductTypeId = 1,
                ProductBrandId = 1

            });
                   
            _dataContext.SaveChanges();

        }

        [Fact]
        public async void GetAllProducts_ReturnsAllProducts()
        {
            // Arrange
            var productRepository = new ProductRepository(_dataContext);

            // Act
            var products = await productRepository.GetAll();

            // Assert
            Assert.Single(products);
            Assert.Contains(products, p => p.Id == 1);
        }

    }
}
