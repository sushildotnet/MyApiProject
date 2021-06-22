using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using MyProjectBL.Handlers.CommandHandlers;
using MyProjectBL.Handlers.QueryHandlers;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectDL.Entities;
using MyProjectDL.Interfaces;
using Xunit;

namespace MyProjectTest.UnitTests
{
    public class ProductsTest
    {
        public Mock<IProductDBService> mock = new Mock<IProductDBService>();


        [Fact]
        public void GetProductById_ReturnsProduct()
        {
            //Arrange
            const int expected = 1;
            const int id = 1;
            mock.Setup(p => p.GetProductById(id)).Returns(new Product() { Id = id });
            var req = new GetProductRequestModel() { Id = id };

            //Act
            var product = new GetProductQueryHandler(mock.Object).Handle(req, CancellationToken.None);

            //Assert
            Assert.Equal(expected, product.Id);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsTrue()
        {
            //Arrange
            const bool expected = true;
            const int id = 1;
            mock.Setup(p => p.DeleteProduct(id)).ReturnsAsync(true);
            var req = new DeleteProductRequestModel() { Id = id };

            //Act
            var result = await new DeleteProductCommandHandler(mock.Object).Handle(req, CancellationToken.None);

            //Assert
            Assert.True(expected.Equals(result.IsDeleted));
        }

        [Fact]
        public async Task UpdateProduct_ReturnsTrue()
        {
            //Arrange
            const bool expected = true;
            mock.Setup(p => p.UpdateProduct(It.IsAny<Product>())).ReturnsAsync(true);
            var req = new UpdateProductRequestModel();
            req.Product = new ProductModel() { Id = 1, Name = "Apple Iphone 13", Description = "Apple IPhone 13", Price = 1500 };
            //Act
            var result = await new UpdateProductCommandHandler(mock.Object).Handle(req, CancellationToken.None);

            //Assert
            Assert.True(expected.Equals(result.IsUpdated));
        }
    }
}
