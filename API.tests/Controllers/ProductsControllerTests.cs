using API.Controllers;
using Core.Entities;
using FluentAssertions;
using Infrastructure.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Cadence.Tests.Controllers
{
    public class ProductsControllerTests
    {
        /*

        [Fact]
        public async void Get_OnSuccess_InvokesUnitOfWorkOnce()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Product.GetAll(null, "ProductBrand,ProductType")).ReturnsAsync(new List<Product>());

            var controller = new ProductsController(mockUnitOfWork.Object);


            //Act

            var result = await controller.GetAllProducts();

            //Assert

            mockUnitOfWork.Verify(x => x.Product.GetAll(null, "ProductBrand,ProductType"), Times.Once());



        }

        [Fact]
        public async void Get_OnSuccess_ReturnsCorrectType()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Product.GetAll(null, "ProductBrand,ProductType")).ReturnsAsync(new List<Product>());

            var controller = new ProductsController(mockUnitOfWork.Object);
            //Act

            var result = await controller.GetAllProducts();

            //Assert
            result.Should().BeOfType<ActionResult<IEnumerable<Product>>>();


        }
        */
        



    }
}