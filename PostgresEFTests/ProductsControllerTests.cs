using Microsoft.AspNetCore.Mvc;
using Moq;
using PostgresEF.Controllers;
using PostgresEF.Factory.Interfaces;
using PostgresEF.Interfaces;
using PostgresEF.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PostgresEFTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductRepository> productRepoMock;
        private readonly Mock<IProductFactory> productFactory;

        public ProductsControllerTests()
        {
            productRepoMock = new Mock<IProductRepository>();
            productFactory = new Mock<IProductFactory>();
        }

        [Fact]
        public async void GetProducts_ShouldReturnAllProducts()
        {
            // arrange
            var itemMock = new Mock<IProduct>();
            itemMock.Setup(x => x.ID).Returns(It.IsAny<int>());

            var products = new List<IProduct>()
            {
                itemMock.Object,
            };

            productRepoMock.Setup(p => p.GetAll())
                .ReturnsAsync(products.AsEnumerable());
            
            // act
            var productsController = new ProductsController(productRepoMock.Object, productFactory.Object);

            var result = await productsController.GetProducts();

            var actual = (result.Result as OkObjectResult).Value;

            // assert
            productRepoMock.Verify(p => p.GetAll(), Times.Once);

            Assert.Equal(products, actual);
        }
    }
}
